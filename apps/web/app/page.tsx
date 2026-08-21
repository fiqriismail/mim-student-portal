import { Button } from "@/components/ui/button";

export default function Home() {
  return (
    <main className="flex flex-1 flex-col items-center justify-center gap-4 p-8">
      <h1 className="text-3xl font-bold text-primary">MIM Student Portal</h1>
      <p className="text-muted-foreground">
        Workspace scaffolded. Design tokens and shadcn/ui wired in.
      </p>
      <Button>Get started</Button>
    </main>
  );
}
