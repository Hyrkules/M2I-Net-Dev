import pygame
import random

# ---------- config ----------
WIDTH, HEIGHT = 800, 600
PLAYER_SIZE = 40
SPEED = 5
OBSTACLE_SIZE = 40
OBSTACLE_SPEED = 5
SPAWN_RATE = 30  # frames per new obstacle
# ----------------------------

pygame.init()
screen = pygame.display.set_mode((WIDTH, HEIGHT))
pygame.display.set_caption("Dodge Game (Keyboard Version)")
clock = pygame.time.Clock()

# Player state
player_x = WIDTH // 2
player_y = HEIGHT - 100

# Obstacles list
obstacles = []

frame_count = 0
running = True

def get_direction():
    keys = pygame.key.get_pressed()
    dx = 0
    dy = 0
    if keys[pygame.K_LEFT]:
        dx = -1
    elif keys[pygame.K_RIGHT]:
        dx = 1
    if keys[pygame.K_UP]:
        dy = -1
    elif keys[pygame.K_DOWN]:
        dy = 1
    return dx, dy

while running:
    clock.tick(60)
    frame_count += 1

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    # --- INPUT ---
    dx, dy = get_direction()

    # --- UPDATE PLAYER ---
    player_x += dx * SPEED
    player_y += dy * SPEED
    player_x = max(0, min(WIDTH - PLAYER_SIZE, player_x))
    player_y = max(0, min(HEIGHT - PLAYER_SIZE, player_y))

    # --- SPAWN OBSTACLES ---
    if frame_count % SPAWN_RATE == 0:
        obs_x = random.randint(0, WIDTH - OBSTACLE_SIZE)
        obs_y = -OBSTACLE_SIZE
        obstacles.append([obs_x, obs_y])

    # --- UPDATE OBSTACLES ---
    for obs in obstacles:
        obs[1] += OBSTACLE_SPEED

    # Remove obstacles that went off-screen
    obstacles = [obs for obs in obstacles if obs[1] < HEIGHT]

    # --- CHECK COLLISIONS ---
    player_rect = pygame.Rect(player_x, player_y, PLAYER_SIZE, PLAYER_SIZE)
    for obs in obstacles:
        obs_rect = pygame.Rect(obs[0], obs[1], OBSTACLE_SIZE, OBSTACLE_SIZE)
        if player_rect.colliderect(obs_rect):
            print("Game Over!")
            running = False

    # --- DRAW ---
    screen.fill((30, 30, 30))
    pygame.draw.rect(screen, (0, 200, 255), player_rect)
    for obs in obstacles:
        pygame.draw.rect(screen, (255, 50, 50), pygame.Rect(obs[0], obs[1], OBSTACLE_SIZE, OBSTACLE_SIZE))

    pygame.display.flip()

pygame.quit()
