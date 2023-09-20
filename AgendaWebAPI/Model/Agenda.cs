using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AgendaWebAPI.Model;

public class Agenda
{
    [Key] public int IdAgenda { get; set; }

    [Display(Name = "Nombre")] public string? Nombre { get; set; }

    [Display(Name = "Teléfono")] public string? Telefono { get; set; }

    [Display(Name = "Dirección")] public string? Direccion { get; set; }
    
    public int IdUsuario { get; set; }
}