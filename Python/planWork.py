import cv2
import numpy as np
from pdf2image import convert_from_path
import os

PDF_PATH = "input/plan.pdf"
OUTPUT_DIR = "output"
DPI = 200

GAUSSIAN_BLUR_SIZE = 7

THRESHOLD_VALUE = 200  # à ajuster selon contraste 200 pas mal 

CLOSE_KERNEL_SIZE = 3
OPEN_KERNEL_SIZE = 3

MIN_AREA_RATIO = 0.01


POPPLER_PATH = None

os.makedirs(OUTPUT_DIR, exist_ok=True)

pages = convert_from_path(
    PDF_PATH,
    dpi=DPI,
    poppler_path=POPPLER_PATH
)

img = np.array(pages[0])

h, w = img.shape[:2]

crop = img[0:h-1000, 0:w-2000]

hsv = cv2.cvtColor(crop, cv2.COLOR_BGR2HSV)
h, s, v = cv2.split(hsv)

mask_color = s > 40
v[mask_color] = 255 

gray = v


blur = cv2.GaussianBlur(
    gray,
    (GAUSSIAN_BLUR_SIZE, GAUSSIAN_BLUR_SIZE),
    0
)

_, bw = cv2.threshold(
    blur,
    THRESHOLD_VALUE,
    255,
    cv2.THRESH_BINARY_INV
)


kernel_close = cv2.getStructuringElement(
    cv2.MORPH_RECT,
    (CLOSE_KERNEL_SIZE, CLOSE_KERNEL_SIZE)
)
closed = cv2.morphologyEx(bw, cv2.MORPH_CLOSE, kernel_close)

kernel = np.ones((7,7), np.uint8)
bw_closed = cv2.morphologyEx(bw, cv2.MORPH_CLOSE, kernel)

num_labels, labels, stats, centroids = cv2.connectedComponentsWithStats(bw_closed, connectivity=8)
sizes = stats[1:, cv2.CC_STAT_AREA]
max_label = 1 + np.argmax(sizes)

main_building = np.zeros_like(bw_closed)
main_building[labels == max_label] = 255

kernel = np.ones((5,5), np.uint8)
main_building_closed = cv2.dilate(main_building, kernel, iterations=1)
main_building_closed = cv2.erode(main_building_closed, kernel, iterations=1)

contours, _ = cv2.findContours(main_building_closed, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
building_contour_img = np.ones_like(bw_closed) * 255
cv2.drawContours(building_contour_img, contours, -1, 0, 2)
cv2.imwrite(f"{OUTPUT_DIR}/building_contour.png", building_contour_img)

kernel_fill = cv2.getStructuringElement(cv2.MORPH_RECT, (15, 15))
filled = cv2.morphologyEx(main_building, cv2.MORPH_CLOSE, kernel_fill)

num_labels, labels, stats, centroids = cv2.connectedComponentsWithStats(filled, connectivity=8)
sizes = stats[1:, cv2.CC_STAT_AREA]
main_label = 1 + np.argmax(sizes)
pieces_closed = np.zeros_like(filled)
pieces_closed[labels == main_label] = 255

contours, hierarchy = cv2.findContours(pieces_closed, cv2.RETR_CCOMP, cv2.CHAIN_APPROX_SIMPLE)

final_plan = np.ones_like(pieces_closed) * 255
for cnt in contours:
    cv2.drawContours(final_plan, [cnt], -1, 0, 2)

cv2.imwrite(f"{OUTPUT_DIR}/final_plan.png", final_plan)
