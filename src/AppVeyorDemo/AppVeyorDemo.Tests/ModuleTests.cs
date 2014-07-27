namespace AppVeyorDemo.Tests
{
    using AppVeyorDemo.Modules;
    using AppVeyorDemo.Tests.Utils;
    using FluentAssertions;
    using Nancy;
    using Nancy.Testing;
    using NUnit.Framework;
    using AppVeyorDemo;

    [TestFixture]
    public class ModuleTests
    {
        private ConfigurableBootstrapper bootstrapper;

        [SetUp]
        public void Setup()
        {
            bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Module<IndexModule>();
                with.RootPathProvider<TestRootPathProvider>();
            });
        }

        [Test]
        public void Should_return_status_ok_when_route_exists()
        {
            // Given
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/", with => with.HttpRequest());

            // Then
            result.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Test]
        public void Should_return_view_with_Hello_AppVeyor()
        {
            // Given
            var bootstrapper = new AppVeyorBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/", with => with.HttpRequest());

            // Then
            result.Body["h1"]
                .ShouldExistOnce()
                .And.ShouldContain("Hello AppVeyor");
        }
    }
}
