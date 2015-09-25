﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ShoppingCart.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ShoppingCartFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ShoppingCart.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ShoppingCart", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "ShoppingCart")))
            {
                ShoppingCart.Specs.ShoppingCartFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calculate Subtotal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShoppingCart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public virtual void CalculateSubtotal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate Subtotal", new string[] {
                        "mytag"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "ProductName",
                        "Price",
                        "Quantity"});
            table1.AddRow(new string[] {
                        "1",
                        "Arroz Progreso",
                        "50",
                        "10"});
            table1.AddRow(new string[] {
                        "2",
                        "Carne",
                        "40",
                        "10"});
            table1.AddRow(new string[] {
                        "3",
                        "Queso",
                        "10",
                        "5"});
#line 8
 testRunner.Given("the cart has the following items", ((string)(null)), table1, "Given ");
#line 13
 testRunner.When("the subtotal is calculated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("the result should be 950", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calculate Subtotal from a stored cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShoppingCart")]
        public virtual void CalculateSubtotalFromAStoredCart()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate Subtotal from a stored cart", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "Quantity",
                        "Owner"});
            table2.AddRow(new string[] {
                        "1",
                        "10",
                        "ccastro"});
            table2.AddRow(new string[] {
                        "2",
                        "10",
                        "ccastro"});
            table2.AddRow(new string[] {
                        "3",
                        "5",
                        "ccastro"});
#line 18
 testRunner.Given("the cart stored for user is", ((string)(null)), table2, "Given ");
#line 23
  testRunner.And("the user logged is \'ccastro\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "ProductName",
                        "Price",
                        "Quantity"});
            table3.AddRow(new string[] {
                        "1",
                        "Arroz Progreso",
                        "50",
                        "200"});
            table3.AddRow(new string[] {
                        "2",
                        "Carne",
                        "40",
                        "300"});
            table3.AddRow(new string[] {
                        "3",
                        "Queso",
                        "10",
                        "250"});
#line 24
  testRunner.And("the products table is the following", ((string)(null)), table3, "And ");
#line 29
 testRunner.When("the subtotal is calculated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("the result should be 950", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Try to calculate Subtotal from a stored cart thats not exceeding product existanc" +
            "e quantity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShoppingCart")]
        public virtual void TryToCalculateSubtotalFromAStoredCartThatsNotExceedingProductExistanceQuantity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Try to calculate Subtotal from a stored cart thats not exceeding product existanc" +
                    "e quantity", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "Quantity",
                        "Owner"});
            table4.AddRow(new string[] {
                        "1",
                        "10",
                        "ccastro"});
            table4.AddRow(new string[] {
                        "2",
                        "10",
                        "ccastro"});
            table4.AddRow(new string[] {
                        "3",
                        "5",
                        "ccastro"});
#line 35
 testRunner.Given("the cart stored for user is", ((string)(null)), table4, "Given ");
#line 40
  testRunner.And("the user logged is \'ccastro\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "ProductName",
                        "Price",
                        "Quantity"});
            table5.AddRow(new string[] {
                        "1",
                        "Arroz Progreso",
                        "50",
                        "10"});
            table5.AddRow(new string[] {
                        "2",
                        "Carne",
                        "40",
                        "10"});
            table5.AddRow(new string[] {
                        "3",
                        "Queso",
                        "10",
                        "5"});
#line 41
  testRunner.And("the products table is the following", ((string)(null)), table5, "And ");
#line 46
 testRunner.When("the subtotal is calculated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.Then("the result should be 950", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Try to calculate Subtotal from a stored cart that is exceeding existance quantity" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShoppingCart")]
        public virtual void TryToCalculateSubtotalFromAStoredCartThatIsExceedingExistanceQuantity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Try to calculate Subtotal from a stored cart that is exceeding existance quantity" +
                    "", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "Quantity",
                        "Owner"});
            table6.AddRow(new string[] {
                        "1",
                        "100",
                        "ccastro"});
            table6.AddRow(new string[] {
                        "2",
                        "100",
                        "ccastro"});
            table6.AddRow(new string[] {
                        "3",
                        "50",
                        "ccastro"});
#line 51
 testRunner.Given("the cart stored for user is", ((string)(null)), table6, "Given ");
#line 56
  testRunner.And("the user logged is \'ccastro\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "ProductName",
                        "Price",
                        "Quantity"});
            table7.AddRow(new string[] {
                        "1",
                        "Arroz Progreso",
                        "50",
                        "70"});
            table7.AddRow(new string[] {
                        "2",
                        "Carne",
                        "40",
                        "83"});
            table7.AddRow(new string[] {
                        "3",
                        "Queso",
                        "10",
                        "50"});
#line 57
  testRunner.And("the products table is the following", ((string)(null)), table7, "And ");
#line 62
 testRunner.When("the subtotal is calculated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.Then("the user is presented with an error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
