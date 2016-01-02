using WatiN.Core;

namespace BankingSite.UITests.PageObjectModelStyle
{
    internal class AcceptedPage : Page
    {
        private const string NameId = "Name";

        public string Name
        {
            get { return Document.Para(Find.ById(NameId)).Text; }            
        }
    }
}