#pragma checksum "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4dc4ce68ccf483996a400fbde0cbbadde9784749"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reviser_GetSugestions), @"mvc.1.0.view", @"/Views/Reviser/GetSugestions.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\_ViewImports.cshtml"
using Geres4U;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\_ViewImports.cshtml"
using Geres4U.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dc4ce68ccf483996a400fbde0cbbadde9784749", @"/Views/Reviser/GetSugestions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b60f060b55dd01c9192fcd525efde6d6e7ef0d11", @"/Views/_ViewImports.cshtml")]
    public class Views_Reviser_GetSugestions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Geres4U.Models.PointOfInterest>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
  
    ViewData["Title"] = "GetSugestions";
    Layout = "_LayoutAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 10 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
 if (Model != null && Model.Count() != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 style=\"position: absolute; left: 600px; top: 100px; font-weight: bold;font-size:25px\">Sugestões</h1>\r\n");
            WriteLiteral("    <dl class=\"row\" style=\"position: absolute; left: 600px;top:200px\">\r\n            \r\n");
#nullable restore
#line 17 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
         foreach (var item in Model)
        {
            var categoryString = item.translateCategory(); 

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-10\" style=\"font-weight: bold; color: green; font-size: 20px; padding: 30px; float: right\">\r\n                ");
#nullable restore
#line 21 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dd class=\"col-sm-10\" style=\"float:left\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 769, "\"", 811, 1);
#nullable restore
#line 24 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
WriteAttributeValue("", 775, Url.Content("~/Images/noImage.png"), 775, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Erro rendering\" width=\"256px\" height=\"256px\"/>\r\n            </dd>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 27 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
           Write(Html.Raw(categoryString));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dd class=\"col-sm-5\" style=\"color: black; font-weight: bold;padding-bottom:30px\">\r\n                ");
#nullable restore
#line 30 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
           Write(Html.ActionLink("Ler mais", "GetSpecificPointOfInterest", "Reviser", new {id = item.Id, ret = "GetSugestions"}, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 32 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
                
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n");
#nullable restore
#line 35 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"


} else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3 style=\"position: absolute; left: 600px; top: 100px; font-weight: bold;font-size:25px\">Sem pontos disponíveis</h3>\r\n");
#nullable restore
#line 40 "C:\Users\ASUS\Documents\GitHub\LI4-Project\Geres4U\Geres4U\Views\Reviser\GetSugestions.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Geres4U.Models.PointOfInterest>> Html { get; private set; }
    }
}
#pragma warning restore 1591