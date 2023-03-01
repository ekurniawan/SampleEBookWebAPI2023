using System;
namespace HelloWebAPI.Models
{
	public class Mahasiswa
	{
        public string NIM { set; get; } = default!;
        public string Nama { set; get; } = default!;
        public string Alamat { set; get; } = default!;
        public string Jurusan { set; get; } = default!;
    }
}

