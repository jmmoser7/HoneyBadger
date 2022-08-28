using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace HoneyBadger
{
    public class GetZ : GH_Component
    {

        public GetZ()
          : base(
                "GetZ", 
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
                v = pl.ZAxis; v.Unitize();

                DA.SetData("out", v);
            }

            if ((Points == (objIn.GetType().ToString())))
            {
                Point3d pt = new Point3d();
                Double d = new Double();
                DA.GetData("geo", ref pt);

                d = pt.Z;
                DA.SetData("out", d);
            }

            if ((Vectors == (objIn.GetType().ToString())))
            {
                Vector3d vec = new Vector3d();
                double d = new Double();
                DA.GetData("geo", ref vec);
                d = vec.Z;
                DA.SetData("out", d);
            }

            if ((planes != (objIn.GetType().ToString())) && (Points != (objIn.GetType().ToString())) && (Vectors != (objIn.GetType().ToString())))
            {
                Vector3d vec = new Vector3d(0, 0, 1);


                DA.SetData("out", vec);
            }

        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {

                return Properties.Resources.PlaneZ;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("5FC11BE5-0419-454E-8BFE-D871856DD5E5"); }
        }
    }
}