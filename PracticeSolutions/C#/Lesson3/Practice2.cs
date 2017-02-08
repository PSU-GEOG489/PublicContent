using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;


namespace Lesson3_Text
{
    public class Practice2 : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public Practice2()
        {
        }

        public void PracticeExercise2()
                {
            IMxDocument pMxDoc;
            pMxDoc = (IMxDocument)ArcMap.Application.Document;

            IMap pMap;
            pMap = pMxDoc.FocusMap;

            IWorkspaceFactory pWSFactory;
            pWSFactory = new ShapefileWorkspaceFactory();

            IWorkspace pWorkspace;
            pWorkspace = pWSFactory.OpenFromFile("c:\\WCGIS\\G5224P\\Lesson1_2_3", ArcMap.Application.hWnd);
            
            //QI
            IFeatureWorkspace pFWorkspace;
            pFWorkspace = (IFeatureWorkspace)pWorkspace;

            string strFileName = "us_boundaries";
            string strLyrName = "U.S. States";
            ShapefileToLayer(pFWorkspace, pMap, strFileName, strLyrName);

            strFileName = "us_cities";
            strLyrName = "U.S. Cities";
            ShapefileToLayer(pFWorkspace, pMap, strFileName, strLyrName);

            IActiveView pActiveView;
            pActiveView = (IActiveView)pMap;
            pActiveView.Refresh();

            pMxDoc.UpdateContents();
        }

        private void ShapefileToLayer(IFeatureWorkspace pFWorkspace, IMap pMap, string strFileName, string strLyrName)
        {
            IFeatureClass pFClass;
            pFClass = pFWorkspace.OpenFeatureClass(strFileName);

            IFeatureLayer pLayer;
            pLayer = new FeatureLayer();
            pLayer.FeatureClass = pFClass;
            pLayer.Name = strLyrName;

            pMap.AddLayer(pLayer);
        }
        
        protected override void OnClick()
        {
            PracticeExercise2();
        }

        protected override void OnUpdate()
        {
        }
    }
}
