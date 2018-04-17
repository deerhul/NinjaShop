using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using PirateShop.Models.ViewModels;

namespace PirateShop.Models.Methods
{
    public class PictureMethod
    {
        private ApplicationDbContext _context;

        public PictureMethod(ApplicationDbContext con)
        {
            _context = con;
        }

        //public string getImage()
        //{
        //    //got it from: https://www.c-sharpcorner.com/UploadFile/mirfan00/uploaddisplay-image-in-picture-box-using-C-Sharp/

        //    // open file dialog   
        //    OpenFileDialog open = new OpenFileDialog();
        //    open.Title = "Upload Image";
        //    // image filters  
        //    open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
        //    if (open.ShowDialog() == DialogResult.OK)
        //    {
        //        return open.FileName;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public void SaveImage(NinjaViewModel vm,string filename)
        {
            vm.ImageFile.SaveAs(filename);
        }
    }
}