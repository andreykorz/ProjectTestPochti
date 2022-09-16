using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestirovanieMailPochti
{
    public class UnitTest1
    {
        private IWebDriver driver;
        private readonly By _signInButton = By.XPath("//button[@class='resplash-btn resplash-btn_primary resplash-btn_mailbox-big svelte-j4p44z']");
        private readonly By _loginInputButton = By.XPath("//input[@placeholder='Имя аккаунта']");
        private readonly By _enterPasswordButton = By.XPath("//span[@class='inner-0-2-81 innerTextWrapper-0-2-82']");
        private readonly By _passwordInputButton = By.XPath("//input[@name='password']");
        private readonly By _signInButton2 = By.XPath("//button[@class='base-0-2-79 primary-0-2-93']");
        private readonly By _sendLetterButton = By.XPath("//span[@class='compose-button__wrapper']");
        private readonly By _closePopupButton = By.XPath("//div[@class='ph-project-promo-close-icon__container svelte-m7oyyo']");
        private readonly By _fieldKomy = By.XPath("//input[@class='container--H9L5q size_s--3_M-_']");
        private readonly By _fieldTextPisma = By.XPath("/ html / body / div[1] / div / div[2] / div / div / div / div[2] / div[3] / div[5] / div / div / div[2] / div[1] / div[1]");
        private readonly By _otpravitButton = By.XPath("//button[@class='base-0-2-14 primary-0-2-28']");
        private readonly By _nameAccountButton = By.XPath("//span[@class='ph-project__user-name svelte-1hiqrvn']");
        private readonly By _exitButton = By.XPath("//div[@class='ph-item ph-item__hover-active svelte-6ia8p0']");
        private readonly By _signIn2User = By.XPath("//button[@class='resplash-btn resplash-btn_primary resplash-btn_mailbox-big svelte-j4p44z']");
        private readonly By _login2UserInputButton = By.XPath("//input[@placeholder='Имя аккаунта']");
        private readonly By _password2UserButton = By.XPath("//span[@class='inner-0-2-81 innerTextWrapper-0-2-82']");
        private readonly By _password2InputButton = By.XPath("//input[@name='password']");
        private readonly By _signInButton3 = By.XPath("//button[@class='base-0-2-79 primary-0-2-93']");
        //private readonly By _closePopupButton2user = By.XPath("//div[@class='cross-0-2-27 mobileCross-0-2-36']");
        private readonly By _openLetterButton = By.XPath("(//span[@class='ll-sp__normal'])[1]");
        private readonly By _actualText = By.XPath("//div[contains(text(),'Привет, Андрей')]");

        const string _login1 = "andrey10test";
        const string _expectedText = "Привет, Андрей";


        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://mail.ru");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        }

      
        [Test]
        public void Test1()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@class='ag-popup__frame__layout__iframe']")));

            var login = driver.FindElement(_loginInputButton);
            Thread.Sleep(1000);
            login.SendKeys(_login1);

            var enterPasswordButton = driver.FindElement(_enterPasswordButton);
            enterPasswordButton.Click();

            var password = driver.FindElement(_passwordInputButton);
            password.SendKeys("Prostojparol)");

            var signIn2 = driver.FindElement(_signInButton2);
            signIn2.Click();
            Thread.Sleep(3000);

            var closePopup = driver.FindElement(_closePopupButton);
            closePopup.Click();

            var sendLetter = driver.FindElement(_sendLetterButton);
            sendLetter.Click();

            var fieldTextPisma = driver.FindElement(_fieldTextPisma);
            fieldTextPisma.Click();
            fieldTextPisma.SendKeys("Привет, Андрей");

            var fieldKomy = driver.FindElement(_fieldKomy);
            fieldKomy.SendKeys("andrey9test@mail.ru");

            var otpravitButton = driver.FindElement(_otpravitButton);
            otpravitButton.Click();
            Thread.Sleep(1000);

            var nameAccountButton = driver.FindElement(_nameAccountButton);
            nameAccountButton.Click();

            var exitButton = driver.FindElement(_exitButton);
            exitButton.Click();

            var signIn2User = driver.FindElement(_signIn2User);
            signIn2User.Click();

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@class='ag-popup__frame__layout__iframe']")));

            var login2User = driver.FindElement(_login2UserInputButton);
            Thread.Sleep(1000);
            login2User.SendKeys("andrey9test");

            var password2UserButton = driver.FindElement(_password2UserButton);
            password2UserButton.Click();

            var password2 = driver.FindElement(_password2InputButton);
            password2.SendKeys("Prostojparol)");

            var signIn3 = driver.FindElement(_signInButton3);
            signIn3.Click();
            Thread.Sleep(3000);

            var openLetter = driver.FindElement(_openLetterButton);
            openLetter.Click();

            //var actualText = driver.FindElement(_fieldTextPisma).Text;

            Assert.AreEqual(_expectedText, _actualText, "The letter not received");

            

        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}