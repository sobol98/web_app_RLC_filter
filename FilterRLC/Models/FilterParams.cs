using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FilterRLC.Models
{
    public class FilterParams
    {
        public int ID { get; set; }
        //---
        [Display(Name = "Resistance R1 [Ohm]")]
        [Required(ErrorMessage = "Please enter resistance value")]
        public double? Resistance_1 { get; set; }

        //---
        [Display(Name = "Resistance R2 [Ohm]")]
        [Required(ErrorMessage = "Please enter resistance value")]
        public double? Resistance_2 { get; set; }

        //---
        [Display(Name = "Inductance [H]")]
        [Required(ErrorMessage = "Please enter inductance value")]
        [Range(0, 100)]
        public double? Inductance { get; set; }
        //---

        [Display(Name = "Capacitance [F]")]
        [Required(ErrorMessage = "Please enter capacitance value")]
        public double? Capacitance { get; set; }
        
        //---
        [Display(Name = "Amplitude of Input Voltage [V]")]
        [Required(ErrorMessage = "Please enter voltage input")]
        public double? U1 { get; set; }
        
        //---
        [Display(Name = "Minimum Frequency [Hz]")]
        [Required(ErrorMessage = "Please enter minimum frequency")]
        public double? Fmin { get; set; }
        
        //---
        [Display(Name = "Maximum Frequency [Hz]")]
        [Required(ErrorMessage = "Please enter maximum frequency")]
        public double? Fmax { get; set; }
        
        //---
        [Display(Name = "Number Of Points")]
        [Required(ErrorMessage = "Please enter the number of waveform points")]
        public int? NumOfRows { get; set; }
    }
}
