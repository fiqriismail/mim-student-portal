import "@testing-library/jest-dom/vitest";

// jsdom doesn't implement ResizeObserver; Radix UI primitives (e.g. Checkbox) need it.
class ResizeObserverStub {
  observe() {}
  unobserve() {}
  disconnect() {}
}

if (typeof globalThis.ResizeObserver === "undefined") {
  globalThis.ResizeObserver = ResizeObserverStub as unknown as typeof ResizeObserver;
}
