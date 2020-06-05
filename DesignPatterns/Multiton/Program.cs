using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            var nikon1 = Camera.GetCamera("NIKON");
            var nikon2 = Camera.GetCamera("NIKON");
            var canon1 = Camera.GetCamera("CANON");
            var canon2 = Camera.GetCamera("CANON");

            Console.WriteLine(nikon1.Id);
            Console.WriteLine(nikon2.Id);
            Console.WriteLine(canon1.Id);
            Console.WriteLine(canon2.Id);

            Console.ReadLine();
        }
    }
    class Camera
    {
        private static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        private static object _lock = new object();
        public Guid Id { get; set; }
        private Camera()
        {
            Id = Guid.NewGuid();
        }
        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
