using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace HoneyBadger
{
    public class GetY : GH_Component
    {

        public GetY()
          : base(
                "GetY", 
                "Nickname",
                "Description",
                "HoneyBadger", 
                "Planes"
                )
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("geo", "d", "", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("out", "o", "", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            String planes = "Grasshopper.Kernel.Types.GH_Plane";
            String Points = "Grasshopper.Kernel.Types.GH_Point";
            String Vectors = "Grasshopper.Kernel.Types.GH_Vector";

            Object objIn = new Object();
            DA.GetData("geo", ref objIn);

            //DA.SetData("wtf", (planes == (objIn.GetType().ToString())));


            if ((planes == (objIn.GetType().ToString())))
            {
                Plane pl = new Plane();
                Vector3d v = new Vector3d();
                DA.GetData("geo", ref pl);
                v = pl.YAxis; v.Unitize();

                DA.SetData("out", v);
            }

            if ((Points == (objIn.GetType().ToString())))
            {
                Point3d pt = new Point3d();
                Double d = new Double();
                DA.GetData("geo", ref pt);

                d = pt.Y;
                DA.SetData("out", d);
            }

            if ((Vectors == (objIn.GetType().ToString())))
            {
                Vector3d vec = new Vector3d();
                double d = new Double();
                DA.GetData("geo", ref vec);
                d = vec.Y;
                DA.SetData("out", d);
            }

            if ((planes != (objIn.GetType().ToString())) && (Points != (objIn.GetType().ToString())) && (Vectors != (objIn.GetType().ToString())))
            {
                Vector3d vec = new Vector3d(0, 1, 0);


                DA.SetData("out", vec);
            }
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {

                return Properties.Resources.PlaneY;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("3D9C8716-7EB2-4488-B5AD-7AD55961435F"); }
        }
    }
}