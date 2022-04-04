using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio1._1
{
    public partial class _Default : Page
    {
        List<Alumno> alumnos = new List<Alumno>();
        List<Inscripciones> inscripcio = new List<Inscripciones>(); 
        private void LeerAlumnos()
        {
            string fileName = Server.MapPath("~/Archivos/Alumno.txt")


            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            
            while (reader.Peek() > -1)
            {
                Alumno alumno = new Alumno();
                alumno.NumerodeCarnet = reader.ReadLine();
                alumno.nombre = reader.ReadLine();

                alumnos.Add(alumno); 
            }
            reader.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LeerAlumnos();
            DropDownList1.DataValueField = "carnet"; 
            DropDownList1.DataSource = alumnos;
            DropDownList1.DataBind(); 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Inscripciones inscripciones = new Inscripciones();

            inscripciones.carne = DropDownList1.SelectedValue;
            inscripciones.grado = Convert.ToInt16(TextBox1);
            inscripciones.fecha = DateTime.Now;

            inscripcio.Add(inscripciones);
            Guardar(); 
        }
        private void Guardar()
        {

            string fileName = Server.MapPath("~/Archivos/Alumno.txt");
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            
            StreamWriter writer = new StreamWriter(stream);
            foreach (var Inscripciones in inscripcio)
            {
                writer.WriteLine(Inscripciones.carne);
                writer.WriteLine(Inscripciones.grado);
                writer.WriteLine(Inscripciones.fecha);
            }       
             writer.Close();
        }
    }
}