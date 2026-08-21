import { test, expect } from "@playwright/test";

test("happy path: fill the form, submit, land on check-email", async ({ page }) => {
  await page.goto("/register");

  await page.getByLabel(/full name/i).fill("Jane Doe");
  await page.getByLabel(/^email/i).fill(`jane.${Date.now()}@example.com`);
  await page.getByLabel(/phone/i).fill("0770000000");
  await page.getByLabel(/^password$/i).fill("verysecurepassword");
  await page.getByLabel(/confirm password/i).fill("verysecurepassword");
  await page.getByLabel(/terms of use/i).check();

  // Cloudflare's documented always-pass test site key (1x00000000000000000000AA,
  // the default this app falls back to when NEXT_PUBLIC_TURNSTILE_SITE_KEY is unset)
  // renders a widget that auto-solves without user interaction. Wait for the submit
  // button to become enabled once the widget's onSuccess callback fires.
  await expect(page.getByRole("button", { name: /create account/i })).toBeEnabled({
    timeout: 15_000,
  });

  await page.getByRole("button", { name: /create account/i }).click();

  await expect(page).toHaveURL(/\/register\/check-email\?email=/, { timeout: 15_000 });
  await expect(page.getByRole("heading", { name: /check your email/i })).toBeVisible();
});
