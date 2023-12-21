using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Lab16.Model;

namespace Lab16
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //{
        //    "libros": [
        //      {
        //        "titulo": "Cien años de soledad",
        //      "autor": "Gabriel García Márquez",
        //      "anio_publicacion": 1967,
        //      "genero": "Realismo mágico",
        //      "editorial": "Sudamericana",
        //      "disponible": true
        //                  },
        //    {
        //                    "titulo": "1984",
        //      "autor": "George Orwell",
        //      "anio_publicacion": 1949,
        //      "genero": "Distopía",
        //      "editorial": "Secker & Warburg",
        //      "disponible": true
        //    },
        //    {
        //                    "titulo": "Matar a un ruiseñor",
        //      "autor": "Harper Lee",
        //      "anio_publicacion": 1960,
        //      "genero": "Novela",
        //      "editorial": "J.B. Lippincott & Co.",
        //      "disponible": false
        //    }
        //  ]
        //}

        public class Libros
        {
            public List<Libro> libros { get; set; }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://alexa-docs.onrender.com/libros");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var libros = JsonConvert.DeserializeObject<Libros>(json);
                lstLibros.ItemsSource = libros.libros;
            }
        }
    }
}
