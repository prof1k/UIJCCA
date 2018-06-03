using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UIJCCA.web.Models
{
    public class UIJCCViewModels
    {
    }
    public class IncidentsModel : DomainModel.Entity.Incidents
    {
        [Display(Name = "Наименование ОПС (ID канала связи)")]
        public IEnumerable<SelectListItem> idObjectList { get; set; }
        public IncidentsModel() { }
        public IncidentsModel(DomainModel.Entity.Incidents incident)
        {
            new IncidentsModel()
            {
                description = incident.description,
                idIncident = incident.idIncident,
                idObject = incident.idObject,
                IncidentClose = incident.IncidentClose,
                incidentNumberIteko = incident.incidentNumberIteko,
                incidentNumberRT = incident.incidentNumberRT,
                incidentOpening = incident.incidentOpening,
                timestamp = incident.timestamp
            };
        }
    }
    public class PostModel
    {
        [Display(Name = "Почтамт")]        
        public IEnumerable<SelectListItem> postList { get; set; }
        [Required(ErrorMessage = "Поле \"Почтамт\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Почтамт")]
        public string post { get; set; }
    }
}