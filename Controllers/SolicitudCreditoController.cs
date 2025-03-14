using Microsoft.AspNetCore.Mvc;
 using Microcredito.Models;
 
 namespace MicrocreditoMVC.Controllers
 {
     public class SolicitudCreditoController : Controller
     {
         public IActionResult Index()
         {
             return View(new SolicitudCredito());
         }
 
         [HttpPost]
         public IActionResult Evaluar(SolicitudCredito solicitud)
         {
             if (!ModelState.IsValid)
             {
                 return View("Index", solicitud);
             }
 
             if (solicitud.MontoSolicitado > solicitud.Salario * 0.3)
             {
                 ViewBag.Mensaje = "❌ Rechazado: No puede solicitar más del 30% de su salario.";
                 return View("Index", solicitud);
             }
 
             if (solicitud.MesesContratacion < 3)
             {
                 ViewBag.Mensaje = "❌ Rechazado: Debe tener al menos 3 meses de contratación.";
                 return View("Index", solicitud);
             }
 
             if ((solicitud.Salario > 2000 && solicitud.FrecuenciaPago != "Semanal") ||
                 (solicitud.Salario <= 2000 && solicitud.FrecuenciaPago == "Semanal"))
             {
                 ViewBag.Mensaje = "✅ Aprobado: Su crédito ha sido aceptado.";
             }
             else
             {
                 ViewBag.Mensaje = "❌ Rechazado: No cumple con los requisitos de frecuencia de pago.";
             }
 
             return View("Index", solicitud);
         }
     }
 }