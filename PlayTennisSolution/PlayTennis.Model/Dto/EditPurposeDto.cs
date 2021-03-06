﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class EditPurposeDto
    {
        ///// <summary>
        ///// 微信用户id
        ///// </summary>
        //public Guid wxUserid { get; set; }
        public Guid Id { get; set; }
        /// <summary>
        /// 运动开始时间
        /// </summary>
        public DateTime? startTime { get; set; }
        /// <summary>
        /// 运动结束时间
        /// </summary>
        public DateTime? endTime { get; set; }
        /// <summary>
        /// 时间是否可以协商
        /// </summary>
        public bool isCanChange { get; set; }
        /// <summary>
        /// 运动意向说明
        /// </summary>
        public string exerciseExplain { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public LocationDto userLocation { get; set; }
        /// <summary>
        /// 微信表单id
        /// </summary>
        public string formId { get; set; }

    }

    public class LocationDto
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double longitude { get; set; }
        /// <summary>
        /// 速度，浮点数，单位m/s
        /// </summary>
        public decimal speed { get; set; }
        /// <summary>
        /// 位置的精确度
        /// </summary>
        public string accuracy { get; set; }
    }
}