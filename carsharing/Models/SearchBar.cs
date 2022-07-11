using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace carsharing.Models
{
    public class SearchBar
    {
        public string SearchField { get; set; } = null!;

        public string DateFrom { get; set; } = null!;

        public string TimeFrom { get; set; } = null!;

        public List<SelectListItem> SelectTimeFrom { get; private set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "00:00", Text = "00:00"},
            new SelectListItem { Value = "00:30", Text = "00:30"},
            new SelectListItem { Value = "01:00", Text = "01:00"},
            new SelectListItem { Value = "01:30", Text = "01:30"},
            new SelectListItem { Value = "02:00", Text = "02:00"},
            new SelectListItem { Value = "02:30", Text = "02:30"},
            new SelectListItem { Value = "03:00", Text = "03:00"},
            new SelectListItem { Value = "03:30", Text = "03:30"},
            new SelectListItem { Value = "04:00", Text = "04:00"},
            new SelectListItem { Value = "04:30", Text = "04:30"},
            new SelectListItem { Value = "05:00", Text = "05:00"},
            new SelectListItem { Value = "05:30", Text = "05:30"},
            new SelectListItem { Value = "06:00", Text = "06:00"},
            new SelectListItem { Value = "06:30", Text = "06:30"},
            new SelectListItem { Value = "07:00", Text = "07:00"},
            new SelectListItem { Value = "07:30", Text = "07:30"},
            new SelectListItem { Value = "08:00", Text = "08:00"},
            new SelectListItem { Value = "08:30", Text = "08:30"},
            new SelectListItem { Value = "09:00", Text = "09:00"},
            new SelectListItem { Value = "09:30", Text = "09:30"},
            new SelectListItem { Value = "10:00", Text = "10:00"},
            new SelectListItem { Value = "10:30", Text = "10:30"},
            new SelectListItem { Value = "11:00", Text = "11:00"},
            new SelectListItem { Value = "11:30", Text = "11:30"},
            new SelectListItem { Value = "12:00", Text = "12:00"},
            new SelectListItem { Value = "12:30", Text = "12:30"},
            new SelectListItem { Value = "13:00", Text = "13:00"},
            new SelectListItem { Value = "13:30", Text = "13:30"},
            new SelectListItem { Value = "14:00", Text = "14:00"},
            new SelectListItem { Value = "14:30", Text = "14:30"},
            new SelectListItem { Value = "15:00", Text = "15:00"},
            new SelectListItem { Value = "15:30", Text = "15:30"},
            new SelectListItem { Value = "16:00", Text = "16:00"},
            new SelectListItem { Value = "16:30", Text = "16:30"},
            new SelectListItem { Value = "17:00", Text = "17:00"},
            new SelectListItem { Value = "17:30", Text = "17:30"},
            new SelectListItem { Value = "18:00", Text = "18:00"},
            new SelectListItem { Value = "18:30", Text = "18:30"},
            new SelectListItem { Value = "19:00", Text = "19:00"},
            new SelectListItem { Value = "19:30", Text = "19:30"},
            new SelectListItem { Value = "20:00", Text = "20:00"},
            new SelectListItem { Value = "20:30", Text = "20:30"},
            new SelectListItem { Value = "21:00", Text = "21:00"},
            new SelectListItem { Value = "21:30", Text = "21:30"},
            new SelectListItem { Value = "22:00", Text = "22:00"},
            new SelectListItem { Value = "22:30", Text = "22:30"},
            new SelectListItem { Value = "23:00", Text = "23:00"},
            new SelectListItem { Value = "23:30", Text = "23:30"}
        };

        public string DateTo { get; set; } = null!;

        public string TimeTo { get; set; } = null!;

        public List<SelectListItem> SelectTimeTo { get; private set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "00:00", Text = "00:00"},
            new SelectListItem { Value = "00:30", Text = "00:30"},
            new SelectListItem { Value = "01:00", Text = "01:00"},
            new SelectListItem { Value = "01:30", Text = "01:30"},
            new SelectListItem { Value = "02:00", Text = "02:00"},
            new SelectListItem { Value = "02:30", Text = "02:30"},
            new SelectListItem { Value = "03:00", Text = "03:00"},
            new SelectListItem { Value = "03:30", Text = "03:30"},
            new SelectListItem { Value = "04:00", Text = "04:00"},
            new SelectListItem { Value = "04:30", Text = "04:30"},
            new SelectListItem { Value = "05:00", Text = "05:00"},
            new SelectListItem { Value = "05:30", Text = "05:30"},
            new SelectListItem { Value = "06:00", Text = "06:00"},
            new SelectListItem { Value = "06:30", Text = "06:30"},
            new SelectListItem { Value = "07:00", Text = "07:00"},
            new SelectListItem { Value = "07:30", Text = "07:30"},
            new SelectListItem { Value = "08:00", Text = "08:00"},
            new SelectListItem { Value = "08:30", Text = "08:30"},
            new SelectListItem { Value = "09:00", Text = "09:00"},
            new SelectListItem { Value = "09:30", Text = "09:30"},
            new SelectListItem { Value = "10:00", Text = "10:00"},
            new SelectListItem { Value = "10:30", Text = "10:30"},
            new SelectListItem { Value = "11:00", Text = "11:00"},
            new SelectListItem { Value = "11:30", Text = "11:30"},
            new SelectListItem { Value = "12:00", Text = "12:00"},
            new SelectListItem { Value = "12:30", Text = "12:30"},
            new SelectListItem { Value = "13:00", Text = "13:00"},
            new SelectListItem { Value = "13:30", Text = "13:30"},
            new SelectListItem { Value = "14:00", Text = "14:00"},
            new SelectListItem { Value = "14:30", Text = "14:30"},
            new SelectListItem { Value = "15:00", Text = "15:00"},
            new SelectListItem { Value = "15:30", Text = "15:30"},
            new SelectListItem { Value = "16:00", Text = "16:00"},
            new SelectListItem { Value = "16:30", Text = "16:30"},
            new SelectListItem { Value = "17:00", Text = "17:00"},
            new SelectListItem { Value = "17:30", Text = "17:30"},
            new SelectListItem { Value = "18:00", Text = "18:00"},
            new SelectListItem { Value = "18:30", Text = "18:30"},
            new SelectListItem { Value = "19:00", Text = "19:00"},
            new SelectListItem { Value = "19:30", Text = "19:30"},
            new SelectListItem { Value = "20:00", Text = "20:00"},
            new SelectListItem { Value = "20:30", Text = "20:30"},
            new SelectListItem { Value = "21:00", Text = "21:00"},
            new SelectListItem { Value = "21:30", Text = "21:30"},
            new SelectListItem { Value = "22:00", Text = "22:00"},
            new SelectListItem { Value = "22:30", Text = "22:30"},
            new SelectListItem { Value = "23:00", Text = "23:00"},
            new SelectListItem { Value = "23:30", Text = "23:30"}
        };
    }
}
