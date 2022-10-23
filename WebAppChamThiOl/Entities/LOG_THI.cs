﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebAppChamThiOl.Data;
using WebAppChamThiOl.Models;

namespace WebAppChamThiOl.Entities
{
    [Table("LogThi")]
    public class LOG_THI
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Đề")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public int DeId { get; set; }

        public double? Diem { get;set; }
        public string SBD { get;set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? NgayThi { get; set; }
        [ForeignKey("DeId")]
        public virtual CATEGORY DE { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual USER USER { get; set; }
    }
}