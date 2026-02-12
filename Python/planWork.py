import cv2
import numpy as np
from pdf2image import convert_from_path
import os

# =============================
# PARAMÈTRES GÉNÉRAUX
# =============================
PDF_PATH = "input/plan.pdf"
OUTPUT_DIR = "output"
DPI = 300

# --- Pré-traitement ---
GAUSSIAN_BLUR_SIZE = 5

# --- Binarisation ---
THRESHOLD_VALUE = 1000  # à ajuster selon contraste

# --- Morphologie ---
CLOSE_KERNEL_SIZE = 9  # fermeture murs / portes (clé anti-ambiguïté)
OPEN_KERNEL_SIZE = 3   # suppression bruit (textes, cotes)

# --- Filtrage composantes ---
MIN_AREA_RATIO = 0.05  # % surface image (garder masse principale)

# --- Poppler (optionnel si non dans PATH) ---
POPPLER_PATH = None
# Exemple :
# POPPLER_PATH = r"C:\Program Files\poppler\Library\bin"

# =============================
# PRÉPARATION
# =============================
os.makedirs(OUTPUT_DIR, exist_ok=True)

# =============================
# 1. PDF → IMAGE
# =============================
pages = convert_from_path(
    PDF_PATH,
    dpi=DPI,
    poppler_path=POPPLER_PATH
)

img = np.array(pages[0])
img = cv2.cvtColor(img, cv2.COLOR_RGB2BGR)
cv2.imwrite(f"{OUTPUT_DIR}/00_original.png", img)

# =============================
# 2. SUPPRESSION DE LA COULEUR (HSV)
# =============================
# Objectif : neutraliser toute chrominance
hsv = cv2.cvtColor(img, cv2.COLOR_BGR2HSV)
h, s, v = cv2.split(hsv)

# Optionnel : écraser les couleurs trop saturées
s[s > 50] = 0

hsv_nocolor = cv2.merge([h, s, v])
gray = hsv_nocolor[:, :, 2]  # canal V = luminosité
cv2.imwrite(f"{OUTPUT_DIR}/01_gray_nocolor.png", gray)

# =============================
# 3. LISSAGE
# =============================
blur = cv2.GaussianBlur(
    gray,
    (GAUSSIAN_BLUR_SIZE, GAUSSIAN_BLUR_SIZE),
    0
)
cv2.imwrite(f"{OUTPUT_DIR}/02_blur.png", blur)

# =============================
# 4. BINARISATION
# =============================
_, bw = cv2.threshold(
    blur,
    THRESHOLD_VALUE,
    255,
    cv2.THRESH_BINARY_INV
)
cv2.imwrite(f"{OUTPUT_DIR}/03_bw.png", bw)

# =============================
# 5. FERMETURE MORPHOLOGIQUE
# =============================
kernel_close = cv2.getStructuringElement(
    cv2.MORPH_RECT,
    (CLOSE_KERNEL_SIZE, CLOSE_KERNEL_SIZE)
)
closed = cv2.morphologyEx(bw, cv2.MORPH_CLOSE, kernel_close)
cv2.imwrite(f"{OUTPUT_DIR}/04_closed.png", closed)

# =============================
# 6. NETTOYAGE (OPEN)
# =============================
kernel_open = cv2.getStructuringElement(
    cv2.MORPH_RECT,
    (OPEN_KERNEL_SIZE, OPEN_KERNEL_SIZE)
)
clean = cv2.morphologyEx(closed, cv2.MORPH_OPEN, kernel_open)
cv2.imwrite(f"{OUTPUT_DIR}/05_clean.png", clean)

# =============================
# 7. SÉLECTION DE LA MASSE PRINCIPALE
# =============================
num_labels, labels, stats, _ = cv2.connectedComponentsWithStats(
    clean,
    connectivity=8
)

h_img, w_img = clean.shape
min_area = h_img * w_img * MIN_AREA_RATIO

main_component = np.zeros_like(clean)

for i in range(1, num_labels):  # 0 = fond
    if stats[i, cv2.CC_STAT_AREA] > min_area:
        main_component[labels == i] = 255

cv2.imwrite(
    f"{OUTPUT_DIR}/06_main_component.png",
    main_component
)

# =============================
# 8. EXTRACTION DU CONTOUR EXTERNE
# =============================
contours, _ = cv2.findContours(
    main_component,
    cv2.RETR_EXTERNAL,
    cv2.CHAIN_APPROX_SIMPLE
)

contour_img = cv2.cvtColor(gray, cv2.COLOR_GRAY2BGR)
cv2.drawContours(contour_img, contours, -1, (0, 0, 255), 3)

cv2.imwrite(
    f"{OUTPUT_DIR}/07_contour.png",
    contour_img
)

print("✔ Traitement terminé avec suppression de la couleur")
