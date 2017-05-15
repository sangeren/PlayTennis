using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Utility
{
    public class LocationHelper
    {
        public static double HaverSin(double theta)
        {
            var v = Math.Sin(theta / 2);
            return v * v;
        }
        static double EARTH_RADIUS = 6371.0;//km 地球半径 平均值，千米
        /// <summary>
        /// 给定的经度1，纬度1；经度2，纬度2. 计算2个经纬度之间的距离。
        /// </summary>
        /// <param name="lat1">经度1</param>
        /// <param name="lon1">纬度1</param>
        /// <param name="lat2">经度2</param>
        /// <param name="lon2">纬度2</param>
        /// <returns>距离（公里、千米）</returns>
        public static double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            //用haversine公式计算球面两点间的距离。
            //经纬度转换成弧度
            lat1 = ConvertDegreesToRadians(lat1);
            lon1 = ConvertDegreesToRadians(lon1);
            lat2 = ConvertDegreesToRadians(lat2);
            lon2 = ConvertDegreesToRadians(lon2);
            //差值
            var vLon = Math.Abs(lon1 - lon2);
            var vLat = Math.Abs(lat1 - lat2);
            //h is the great circle distance in radians, great circle就是一个球体上的切面，它的圆心即是球心的一个周长最大的圆。
            var h = HaverSin(vLat) + Math.Cos(lat1) * Math.Cos(lat2) * HaverSin(vLon);
            var distance = 2 * EARTH_RADIUS * Math.Asin(Math.Sqrt(h));
            return distance;
        }
        /// <summary>
        /// 将角度换算为弧度。
        /// </summary>
        /// <param name="degrees">角度</param>
        /// <returns>弧度</returns>
        public static double ConvertDegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        public static double ConvertRadiansToDegrees(double radian)
        {
            return radian * 180.0 / Math.PI;
        }
    }
    public struct MapPoint
    {
        public MapPoint(double lng, double lat)
        {
            Lng = lng;
            Lat = lat;
        }
        /// <summary>
        /// 坐标X -->经度
        /// </summary>
        public double Lng;
        /// <summary>
        /// 坐标Y -->纬度
        /// </summary>
        public double Lat;

        public bool Valid()
        {
            return (double?)Lng != null && (double?)Lat != null && Lng != 0 && Lat != 0;
        }
    }
    public struct MapOption
    {
        //范围方式
        public const int Circle = 1;
        public const int Square = 2;
    }
    public struct MapTool
    {
        public static double ToRadians(double d)
        {
            return Math.PI * d / 180;
        }

        public static double ToDegree(double d)
        {
            return d / (Math.PI / 180);
        }
    }

    /// <summary>
    /// 百度地图
    /// </summary>
    public sealed class BaiduMap
    {
        //半径，米
        public const double EarthRadius = 6370996.81;

        /// <summary>
        /// 两点距离,返回km
        /// </summary>
        /// <param name="coor1"></param>
        /// <param name="coor2"></param>
        /// <returns></returns>
        public static double GetDistance(MapPoint coor1, MapPoint coor2)
        {
            if (!coor1.Valid() || !coor2.Valid())
            {
                return 0;
            }

            coor1.Lng = GetLoop(coor1.Lng, -180, 180);
            coor1.Lat = GetRange(coor1.Lat, -74, 74);
            coor2.Lng = GetLoop(coor2.Lng, -180, 180);
            coor2.Lat = GetRange(coor2.Lat, -74, 74);
            double lng1, lng2, lat1, lat2;
            lng1 = MapTool.ToRadians(coor1.Lng);
            lat1 = MapTool.ToRadians(coor1.Lat);
            lng2 = MapTool.ToRadians(coor2.Lng);
            lat2 = MapTool.ToRadians(coor2.Lat);
            return GetDistance(lng1, lng2, lat1, lat2);
        }

        /// <summary>
        /// 两点距离,返回km
        /// </summary>
        /// <param name="lng1"></param>
        /// <param name="lng2"></param>
        /// <param name="lat1"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        public static double GetDistance(double lng1, double lng2, double lat1, double lat2)
        {
            double distance = BaiduMap.EarthRadius * Math.Acos((Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lng2 - lng1)));
            return Math.Round(distance / 1000, 2);
        }

        public static double GetLoop(double lng, double a, double b)
        {
            while (lng > b)
            {
                lng -= b - a;
            }
            while (lng < a)
            {
                lng += b - a;
            }
            return lng;
        }

        public static double GetRange(double lat, double a, double b)
        {
            if ((double?)a != null)
            {
                lat = Math.Max(lat, a);
            }

            if ((double?)b != null)
            {
                lat = Math.Min(lat, b);
            }
            return lat;
        }

        public static MapPoint[] Range(MapPoint point, double range, int type)
        {
            List<MapPoint> ps = new List<MapPoint>();
            double d = range * 1000 / 6378800;
            double e = Math.PI / 180 * point.Lat;
            double f = Math.PI / 180 * point.Lng;
            int delta = type == MapOption.Square ? 90 : 9;

            //每delta叠加一次
            //cos(0)=sin(π/2)=1,从π/2起正角度旋转
            for (int g = 0; 360 >= g; g += delta)
            {
                double i = Math.PI / 180 * g;
                double k = Math.Asin(Math.Sin(e) * Math.Cos(d) + Math.Cos(e) * Math.Sin(d) * Math.Cos(i));
                MapPoint p = new MapPoint(((f - Math.Atan2(Math.Sin(i) * Math.Sin(d) * Math.Cos(e), Math.Cos(d) - Math.Sin(e) * Math.Sin(k)) + Math.PI) % (2 * Math.PI) - Math.PI) * (180 / Math.PI), k * (180 / Math.PI));
                ps.Add(p);
            }
            return ps.ToArray();
        }
    }

    /// <summary>
    /// 腾讯地图
    /// </summary>
    public sealed class TencentMap
    {
        //半径，米
        public const double EarthRadius = 6378136.49;

        public static double GetDistance(MapPoint coor1, MapPoint coor2)
        {
            double c = MapTool.ToRadians(coor1.Lat) - MapTool.ToRadians(coor2.Lat),
                    e = MapTool.ToRadians(coor1.Lng) - MapTool.ToRadians(coor2.Lng);
            c = Math.Sin(c / 2) * Math.Sin(c / 2) + Math.Cos(MapTool.ToRadians(coor2.Lat)) * Math.Cos(MapTool.ToRadians(coor1.Lat)) * Math.Sin(e / 2) * Math.Sin(e / 2);
            c = 2 * Math.Atan2(Math.Sqrt(c), Math.Sqrt(1 - c));
            return Math.Round(EarthRadius * c) / 1000;
        }

        public static MapPoint[] Range(MapPoint point, double range, int type)
        {
            List<MapPoint> ps = new List<MapPoint>();
            double d = range * 1000 / EarthRadius;
            double e = Math.PI / 180 * point.Lat;
            double f = Math.PI / 180 * point.Lng;
            int delta = type == MapOption.Square ? 90 : 9;

            //每delta叠加一次
            //cos(0)=sin(π/2)=1,从π/2起正角度旋转
            for (int g = 0; 360 >= g; g += delta)
            {
                double i = Math.PI / 180 * g;
                double k = Math.Asin(Math.Sin(e) * Math.Cos(d) + Math.Cos(e) * Math.Sin(d) * Math.Cos(i));
                MapPoint p = new MapPoint(((f - Math.Atan2(Math.Sin(i) * Math.Sin(d) * Math.Cos(e), Math.Cos(d) - Math.Sin(e) * Math.Sin(k)) + Math.PI) % (2 * Math.PI) - Math.PI) * (180 / Math.PI), k * (180 / Math.PI));
                ps.Add(p);
            }
            return ps.ToArray();
        }

        /// <summary>
        /// 两点距离,返回km
        /// </summary>
        /// <param name="lng1"></param>
        /// <param name="lng2"></param>
        /// <param name="lat1"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        public static double GetDistance(double lng1, double lng2, double lat1, double lat2)
        {
            double distance = TencentMap.EarthRadius * Math.Acos((Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lng2 - lng1)));
            return Math.Round(distance / 1000, 2);
        }

    }
}
