using System;
 using System.ComponentModel.DataAnnotations;
 
 namespace Microcredito.Models
 {
     public class SolicitudCredito
     {
         [Required(ErrorMessage = "El nombre es obligatorio.")]
         public string Nombre { get; set; }
 
         [Required(ErrorMessage = "El DNI es obligatorio.")]
         public string DNI { get; set; }
 
         [Required(ErrorMessage = "Debe ingresar la fecha de contratación.")]
         [DataType(DataType.Date)]
         public DateTime FechaContratacion { get; set; }
 
         [Required(ErrorMessage = "El salario es obligatorio.")]
         [Range(1, double.MaxValue, ErrorMessage = "El salario debe ser mayor a 0.")]
         public double Salario { get; set; }
 
         [Required(ErrorMessage = "Debe seleccionar la frecuencia de pago.")]
         public string FrecuenciaPago { get; set; }
 
         [Required(ErrorMessage = "Debe ingresar el monto solicitado.")]
         [Range(1, double.MaxValue, ErrorMessage = "El monto solicitado debe ser mayor a 0.")]
         public double MontoSolicitado { get; set; }
 
         public int MesesContratacion => (DateTime.Now - FechaContratacion).Days / 30;
     }
 }