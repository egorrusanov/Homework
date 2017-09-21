using OpenQA.Selenium;

namespace TestCloudControl.Common
{
    /// <summary>
    /// Фабрика страниц, инициализация элементов
    /// </summary>
    public class PageFactory
    {
        /// <summary>
        /// Получение страницы в виде объекта
        /// </summary>
        /// <typeparam name="T">Тип страницы</typeparam>
        /// <param name="driver">Драйвер</param>
        /// <returns>Объект соответствующего типа</returns>
        public T GetPage<T>(IWebDriver driver) where T : new()
        {
            var page = new T();
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(driver, page);
            return page;
        }
    }
}