using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Examen.Models;
namespace Examen.Controllers
{
    public class HomeController : Controller
    {
        public int existe = 0;
        public int existeT = 0;
        public List<string> ListResultados = new List<string>();
        public Coordenadas coordenadas = new Coordenadas();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Prueba() {
            /*EN GlobalVariables SE OBTENDAN LOS CODIGOS PARA CONECTARSE A LA API*/
            IEnumerable<Coordenadas> List;
            HttpResponseMessage response = ConexionApi.WebApiClient.GetAsync("TableCoordenadas").Result;
            //se guarda en la lista todos los datos obtenidos de la api
            List = response.Content.ReadAsAsync<IEnumerable<Coordenadas>>().Result;
            return View(List);
            //return View();
        }
        [HttpGet]
        public ActionResult Buscar(string filtro)
        {
            if (filtro !=null && filtro !="")
            {
                string[] secuencias = { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" };
                string resultado = "";
                char CharResult;
                int i = 0;
                int iFiltro = 0;
                string result;
                foreach (string caracteres in secuencias)
                {

                    while (i < secuencias.Length)
                    {
                        if (iFiltro < filtro.Length)
                        {

                            CharResult = filtro[iFiltro];
                            resultado = CharResult.ToString();
                            //resultado = filtro.Substring(iFiltro, 1).ToUpper();

                            if (filtro == "TELEFE" || filtro == "telefe")
                            {
                                result = obtenerPosicionesTelefe(caracteres, resultado.ToUpper(), filtro);
                                ListResultados.Add(result);
                                iFiltro++;
                                agregar(result, filtro);
                            }
                            else
                            {
                                foreach (char carac in caracteres)
                                {
                                    if (carac.ToString() == resultado.ToUpper())
                                    {
                                        result = obtenerPosiciones(caracteres, resultado.ToUpper(), filtro);
                                        ListResultados.Add(result);
                                        iFiltro++;
                                        agregar(result, filtro);
                                    }
                                }
                            }
                            i++;
                            existe = 0;

                            break;
                        }
                        else
                        {
                            break;
                        }

                    }

                }
                //return View("Prueba");
            }
            return View();

        }
        public void agregar(string result, string filtro) {
            coordenadas.coordenadas = result;
            coordenadas.palabra = filtro;
            HttpResponseMessage responde = ConexionApi.WebApiClient.PostAsJsonAsync("TableCoordenadas", coordenadas).Result;
        }
        public string obtenerPosicionesTelefe(string secuencia, string caracter, string filtro) {
            int y = 0;
            int x = 0;
            string re = caracter.ToUpper();
            string fil = filtro.ToUpper();
            secuencia = "TELEFE";
            if (secuencia == "TELEFE")
            {
                x = 7;

                if (caracter == "T")
                {
                    y = 1;
                }
                else if (caracter == "E")
                {

                    if (existeT == 0)
                    {
                        y = 2;
                        existeT = 1;
                    }
                    else if (existeT == 1)
                    {
                        y = 4;
                        existeT = 2;
                    }
                    else if (existeT == 2)
                    {
                        y = 6;
                    }
                }
                else if (caracter == "L")
                {
                    y = 3;
                }
                else if (caracter == "F")
                {
                    y = 5;
                }
            }
            string posicion = x + "," + y;

            return posicion;

        }
        public string obtenerPosiciones(string secuencia,string caracter,string filtro) {
            int y = 0;
            int x = 0;
            string re = caracter.ToUpper();
            string fil = filtro.ToUpper();

            if (secuencia == "AGVNFT")
            {
                x = 1;
                switch (re.ToUpper())
                {
                    case "A":
                        y = 1;
                        break;
                    case "G":
                        y = 2;
                        break;
                    case "V":
                        y = 3;
                        break;
                    case "N":
                        y = 4;
                        break;
                    case "F":
                        y = 5;
                        break;
                    case "T":
                        y = 6;
                        break;
                }
            }
            else if (secuencia == "XJILSB")
            {
                x = 2;
                switch (caracter)
                {
                    case "X":
                        y = 1;
                        break;
                    case "J":
                        y = 2;
                        break;
                    case "I":
                        y = 3;
                        break;
                    case "L":
                        y = 4;
                        break;
                    case "S":
                        y = 5;
                        break;
                    case "B":
                        y = 6;
                        break;
                }
            }
            else if (secuencia == "CHAOHD")
            {
                x = 3;
                //int existe = 0;
                if (caracter=="C")
                {
                    y = 1;
                }
                else if (caracter == "H")
                {
                    if (existe==0)
                    {
                        y = 2;
                        existe = 1;
                    }
                    else
                    {
                        y = 4;
                    }
                }
                else if (caracter == "A")
                {
                    y = 3;
                }
                else if (caracter == "O")
                {
                    y = 4;
                }
                else if (caracter == "H")
                {
                    y = 5;
                }
            }
            else if (secuencia == "ERCVTQ")
            {
                x = 4;
                switch (caracter)
                {
                    case "E":
                        y = 1;
                        break;
                    case "R":
                        y = 2;
                        break;
                    case "C":
                        y = 3;
                        break;
                    case "V":
                        y = 4;
                        break;
                    case "T":
                        y = 5;
                        break;
                    case "Q":
                        y = 6;
                        break;
                }
            }
            else if (secuencia == "ASOYAO")
            {
                x = 5;
                //int existe = 0;
                if (caracter=="A")
                {
                    if (existe!=0)
                    {
                        y = 1;
                        existe = 0;
                    }
                    else
                    {
                        y = 5;
                    }
                }
                else if (caracter == "S")
                {
                    y = 2;
                }
                else if (caracter == "O")
                {
                    if (existe ==0 )
                    {
                        y = 3;
                        existe = 1;
                    }
                    //else
                    //{
                    //    y = 6;
                    //}
                }
                else if (caracter == "Y")
                {
                    y = 4;
                }

            }
            else if (secuencia == "ERMYUA")
            {
                x = 6;
                switch (caracter)
                {
                    case "E":
                        y = 1;
                        break;
                    case "R":
                        y = 2;
                        break;
                    case "M":
                        y = 3;
                        break;
                    case "Y":
                        y = 4;
                        break;
                    case "U":
                        y = 5;
                        break;
                    case "A":
                        y = 6;
                        break;
                }
            }
            string posicion =  x + "," + y ;

            return posicion;
        }

        }
    }
