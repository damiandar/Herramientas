#pragma checksum "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1874cd2e0fc73cb3ce67db324c1fc3f09488aab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Socios_Cumpleanios), @"mvc.1.0.view", @"/Views/Socios/Cumpleanios.cshtml")]
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
#line 1 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/_ViewImports.cshtml"
using ProyClase3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/_ViewImports.cshtml"
using ProyClase3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1874cd2e0fc73cb3ce67db324c1fc3f09488aab", @"/Views/Socios/Cumpleanios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08707b262303ca017ba75bdb4c4a1625bd3b85d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Socios_Cumpleanios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Socios>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
  
    ViewData["Title"] = "Gymnasio Olimpia";
    var mensaje=ViewBag.mensaje;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Cumpleaños Del Mes</h1>\r\n    <h1>");
#nullable restore
#line 9 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
   Write(mensaje);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    ");
#nullable restore
#line 10 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
Write(Html.ActionLink("Volver","Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <table class=\"table\">\r\n        <tr>\r\n            <th>Nro. Socio</th>\r\n            <th>Nombre</th>\r\n            <th>Apellido</th>\r\n            <th>Cumpleaños</th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 21 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
     foreach (var Socios in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n                <td>");
#nullable restore
#line 24 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
               Write(Socios.NroSocio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
               Write(Socios.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
               Write(Socios.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
               Write(Socios.fecha_nac.ToString("dd/MM/yy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                \r\n                \r\n        </tr>\r\n");
#nullable restore
#line 31 "/Users/damianrosso/Desktop/ProyHerramientas/ProyClase5demo/Views/Socios/Cumpleanios.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Socios>> Html { get; private set; }
    }
}
#pragma warning restore 1591
