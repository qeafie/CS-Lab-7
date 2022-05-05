using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS_Lab_7.Models
{
    public class GuestResponse
    {
        
        public int GuestResponseID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите email")]
        [RegularExpression(@"([a-zA-z])(.+)([a-zA-z])@((g)?mail|yahoo|rambler|yandex|ya)[\.](ru|com)$", ErrorMessage = "Некоректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите, примите ли участие в вечеринке")]
        public bool? WillAttend { get; set; }
    }
}