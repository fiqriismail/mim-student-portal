using Xunit;

// RegisterEndpointTests and RegisterEndpointRateLimitTests each get their own
// WebApplicationFactory<Program> instance (via IClassFixture<RegisterEndpointFactory>),
// so their in-memory rate-limiter partition state ("unknown") never leaks between
// the two classes regardless of run order. But both classes still point at the
// same physical database (student_portal_db_test) — there is no per-class database
// isolation. xUnit runs different test classes in different collections by
// default, and different collections can execute in parallel with each other.
// If these two classes' InitializeAsync/test bodies ran concurrently, their
// RemoveRange + SaveChangesAsync cleanup against the shared Users/StudentProfiles/
// Tokens tables can race and throw an EF Core concurrency exception. Disabling
// test parallelization for this assembly makes all test classes run sequentially,
// which removes that race without weakening the rate-limiter isolation the split
// was designed to provide.
[assembly: CollectionBehavior(DisableTestParallelization = true)]
