using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace HoneyBadger
{
    public class CurveSmooth : GH_Component
    {

        public CurveSmooth()
          : base(
                "CurveSmooth",
                "cs",
                "smoothe a curve",
                "HoneyBadger",
                "Curves"
             )
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("curve", "c", "", GH_ParamAccess.item);
            pManager.AddNumberParameter("factor", "f", "", GH_ParamAccess.item, 0.5);
            pManager.AddNumberParameter("iterations", "i", "", GH_ParamAccess.item , 1);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("curve", "c", "", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.curveSmoothing;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("372F76DD-640B-46F3-8600-2E42EC7A0D22"); }
        }
    }
}