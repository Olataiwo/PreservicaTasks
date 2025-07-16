using  Microsoft.Playwright;

namespace UiSignUpTest
{
    public class Tests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync();
            _page = await _browser.NewPageAsync();
        }

        [Test]
        public async Task SignUpTest()
        {

            await _page.GotoAsync("https://api.nasa.gov");
            //await page.ClickAsync("text=Browse APIs");
            await _page.ClickAsync("text=Get Started");
            await _page.FillAsync("input[name='user[first_name]']", "Test");
            await _page.FillAsync("input[name='user[last_name]']", "User");
            await _page.ClickAsync("text=Sign Up");
            var email = $"testuser_{Guid.NewGuid():N}@example.com";
            await _page.FillAsync("input[name='user[email]']", email);
            await _page.ClickAsync("text=Sign up");

        }
    }
}