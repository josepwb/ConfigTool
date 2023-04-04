using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		//Created for Revolution RaiderZ by José Lucas
		//Date 04/04/2023

        public string ConfigFileName = "config.xml";

        private void Form1_Load(object sender, EventArgs e)
        {
			string root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Raiderz\\Save\\");

            // If directory does not exist, create it.
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Raiderz\\Save\\" + ConfigFileName);
            XmlDocument doc = new XmlDocument();

            if (!File.Exists(filePath))
            {
                doc.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><CONFIG><AUDIO></AUDIO><VIDEO></VIDEO></CONFIG>");
                doc.Save(filePath);
            }
            else
            {
                doc.Load(filePath);
            }

            //string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            //string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            //MessageBox.Show("your pc resolution is:" + screenWidth + "x" + screenHeight);

            // ScreenMode
            XmlNode ScreenModeNode = doc.SelectSingleNode("/CONFIG/VIDEO/SCREENMODE");
            if (ScreenModeNode != null)
            {
                if (ScreenModeNode.InnerText == "0")
                {
                    check_screen1.Checked = true;
                }
                if (ScreenModeNode.InnerText == "1")
                {
                    check_screen2.Checked = true;
                }
                if (ScreenModeNode.InnerText == "2")
                {
                    check_screen3.Checked = true;
                }
            }

            // Dept of Field
            XmlNode NormalMappingNode = doc.SelectSingleNode("/CONFIG/VIDEO/NORMALMAPPING");
            if (NormalMappingNode != null)
            {
                if (NormalMappingNode.InnerText == "TRUE")
                {
                    check_nmap.Checked = true;
                }
                if (NormalMappingNode.InnerText == "FALSE")
                {
                    check_nmap.Checked = false;
                }
            }

            // Dept of Field
            XmlNode DofNode = doc.SelectSingleNode("/CONFIG/VIDEO/DOF");
            if (DofNode != null)
            {
                if (DofNode.InnerText == "TRUE")
                {
                    check_dof.Checked = true;
                }
                if (DofNode.InnerText == "FALSE")
                {
                    check_dof.Checked = false;
                }
            }

            // HDR
            XmlNode HDRNode = doc.SelectSingleNode("/CONFIG/VIDEO/HDR");
            if (HDRNode != null)
            {
                if (HDRNode.InnerText == "FALSE")
                {
                    check_hdr.Checked = true;
                }
                if (HDRNode.InnerText == "TRUE")
                {
                    check_hdr.Checked = true;
                }
            }

            // Motion Blur
            XmlNode MotionBlurNode = doc.SelectSingleNode("/CONFIG/VIDEO/MOTIONBLUR");
            if (MotionBlurNode != null)
            {
                if (MotionBlurNode.InnerText == "FALSE")
                {
                    check_mb.Checked = true;
                }
                if (MotionBlurNode.InnerText == "TRUE")
                {
                    check_mb.Checked = true;
                }
            }

            // SOFTPARTICLE
            XmlNode SoftParticlesNode = doc.SelectSingleNode("/CONFIG/VIDEO/SOFTPARTICLE");
            if (SoftParticlesNode != null)
            {
                if (SoftParticlesNode.InnerText == "FALSE")
                {
                    check_pe.Checked = true;
                }
                if (SoftParticlesNode.InnerText == "TRUE")
                {
                    check_pe.Checked = true;
                }
            }

            // Screen Space Ambient Occlusion
            XmlNode SSAONode = doc.SelectSingleNode("/CONFIG/VIDEO/SSAO");
            if (SSAONode != null)
            {
                if (SSAONode.InnerText == "FALSE")
                {
                    check_spao.Checked = true;
                }
                if (SSAONode.InnerText == "TRUE")
                {
                    check_spao.Checked = true;
                }
            }

            // Saturation Effect
            XmlNode ColorGradingNode = doc.SelectSingleNode("/CONFIG/VIDEO/COLORGRADING");
            if (ColorGradingNode != null)
            {
                if (ColorGradingNode.InnerText == "FALSE")
                {
                    check_se.Checked = true;
                }
                if (ColorGradingNode.InnerText == "TRUE")
                {
                    check_se.Checked = true;
                }
            }

            // Resolution
            XmlNode HeightNode = doc.SelectSingleNode("/CONFIG/VIDEO/HEIGHT");
            XmlNode WidthNode = doc.SelectSingleNode("/CONFIG/VIDEO/WIDTH");
            if (HeightNode != null && WidthNode != null) 
            {
                string Resolution = WidthNode.InnerText + "x" + HeightNode.InnerText;
                comboResolution.SelectedIndex = comboResolution.FindStringExact(Resolution);
            }

            // Shadow
            XmlNode ShadowNode = doc.SelectSingleNode("/CONFIG/VIDEO/SHADOW");
            if (ShadowNode != null)
            {
                if (ShadowNode.InnerText == "0")
                {
                    check_Shadow0.Checked = true;
                }
                if (ShadowNode.InnerText == "1")
                {
                    check_Shadow1.Checked = true;
                }
                if (ShadowNode.InnerText == "2")
                {
                    check_Shadow2.Checked = true;
                }
                if (ShadowNode.InnerText == "3")
                {
                    check_Shadow3.Checked = true;
                }
                if (ShadowNode.InnerText == "4")
                {
                    check_Shadow4.Checked = true;
                }
                if (ShadowNode.InnerText == "5")
                {
                    check_Shadow5.Checked = true;
                }
            }

            // Light Source
            XmlNode LightSourceNode = doc.SelectSingleNode("/CONFIG/VIDEO/LIGHTING");
            if (LightSourceNode != null)
            {
                if (LightSourceNode.InnerText == "1")
                {
                    check_Light1.Checked = true;
                }
                if (LightSourceNode.InnerText == "2")
                {
                    check_Light2.Checked = true;
                }
            }

            // MinPerformance
            XmlNode MinPerformanceNode = doc.SelectSingleNode("/CONFIG/VIDEO/MINPERFORMANCE");
            if (MinPerformanceNode != null)
            {
                if (MinPerformanceNode.InnerText == "TRUE")
                {
                    check_minimum.Checked = true;
                }
                if (MinPerformanceNode.InnerText == "FALSE")
                {
                    check_minimum.Checked = false;
                }
            }

            // TexResolution
            XmlNode TexResolutionNode = doc.SelectSingleNode("/CONFIG/VIDEO/TEXTUREREDUCTION");
            if (TexResolutionNode != null)
            {
                if (TexResolutionNode.InnerText == "2")
                {
                    check_Tex1.Checked = true;
                }
                if (TexResolutionNode.InnerText == "1")
                {
                    check_Tex2.Checked = true;
                }
                if (TexResolutionNode.InnerText == "0")
                {
                    check_Tex3.Checked = true;
                }
            }

            // LodFactor
            XmlNode LodFactorNode = doc.SelectSingleNode("/CONFIG/VIDEO/LODFACTOR");
            XmlNode OBJRangeNode = doc.SelectSingleNode("/CONFIG/VIDEO/GRNDOBJVISIBLERANGE");
            if (LodFactorNode != null && OBJRangeNode != null)
            {
                if (LodFactorNode.InnerText == "2.00" && OBJRangeNode.InnerText == "1000")
                {
                    check_Terrain1.Checked = true;
                }
                if (LodFactorNode.InnerText == "1.75" && OBJRangeNode.InnerText == "3000")
                {
                    check_Terrain2.Checked = true;
                }
                if (LodFactorNode.InnerText == "1.50" && OBJRangeNode.InnerText == "5000")
                {
                    check_Terrain3.Checked = true;
                }
                if (LodFactorNode.InnerText == "1.25" && OBJRangeNode.InnerText == "7000")
                {
                    check_Terrain4.Checked = true;
                }
                if (LodFactorNode.InnerText == "1.00" && OBJRangeNode.InnerText == "9000")
                {
                    check_Terrain5.Checked = true;
                }
            }

            // AmbientSound
            XmlNode AmbientSoundNode = doc.SelectSingleNode("/CONFIG/AUDIO/GENERICVOLUME");
            if (AmbientSoundNode != null)
            {
                if (AmbientSoundNode.InnerText == "0.00")
                {
                    check_AmVol0.Checked = true;
                }
                if (AmbientSoundNode.InnerText == "0.25")
                {
                    check_AmVol1.Checked = true;
                }
                if (AmbientSoundNode.InnerText == "0.50")
                {
                    check_AmVol2.Checked = true;
                }
                if (AmbientSoundNode.InnerText == "0.75")
                {
                    check_AmVol3.Checked = true;
                }
                if (AmbientSoundNode.InnerText == "1.00")
                {
                    check_AmVol4.Checked = true;
                }
            }

            // MainSound
            XmlNode MainSoundNode = doc.SelectSingleNode("/CONFIG/AUDIO/MASTERVOLUME");
            if (MainSoundNode != null)
            {
                if (MainSoundNode.InnerText == "0.00")
                {
                    check_MVol0.Checked = true;
                }
                if (MainSoundNode.InnerText == "0.25")
                {
                    check_MVol1.Checked = true;
                }
                if (MainSoundNode.InnerText == "0.50")
                {
                    check_MVol2.Checked = true;
                }
                if (MainSoundNode.InnerText == "0.75")
                {
                    check_MVol3.Checked = true;
                }
                if (MainSoundNode.InnerText == "1.00")
                {
                    check_MVol4.Checked = true;
                }
            }

            // BackSound
            XmlNode BackSoundNode = doc.SelectSingleNode("/CONFIG/AUDIO/BGMVOLUME");
            if (BackSoundNode != null)
            {
                if (BackSoundNode.InnerText == "0.00")
                {
                    check_BackVol0.Checked = true;
                }
                if (BackSoundNode.InnerText == "0.25")
                {
                    check_BackVol1.Checked = true;
                }
                if (BackSoundNode.InnerText == "0.50")
                {
                    check_BackVol2.Checked = true;
                }
                if (BackSoundNode.InnerText == "0.75")
                {
                    check_BackVol3.Checked = true;
                }
                if (BackSoundNode.InnerText == "1.00")
                {
                    check_BackVol4.Checked = true;
                }
            }

            // EffectSound
            XmlNode EffectSoundNode = doc.SelectSingleNode("/CONFIG/AUDIO/EFFECTVOLUME");
            if (EffectSoundNode != null)
            {
                if (EffectSoundNode.InnerText == "0.00")
                {
                    check_EffectVol0.Checked = true;
                }
                if (EffectSoundNode.InnerText == "0.25")
                {
                    check_EffectVol1.Checked = true;
                }
                if (EffectSoundNode.InnerText == "0.50")
                {
                    check_EffectVol2.Checked = true;
                }
                if (EffectSoundNode.InnerText == "0.75")
                {
                    check_EffectVol3.Checked = true;
                }
                if (EffectSoundNode.InnerText == "1.00")
                {
                    check_EffectVol4.Checked = true;
                }
            }

            // Hardacceleration
            XmlNode HardAccelNode = doc.SelectSingleNode("/CONFIG/AUDIO/HARDWAREACC");
            if (HardAccelNode != null)
            {
                if (HardAccelNode.InnerText == "TRUE")
                {
                    check_hardacce.Checked = true;
                }
                if (HardAccelNode.InnerText == "FALSE")
                {
                    check_hardacce.Checked = false;
                }
            }

            // Hardacceleration
            XmlNode MuteinWindNode = doc.SelectSingleNode("/CONFIG/AUDIO/INACTIVESOUND");
            if (MuteinWindNode != null)
            {
                if (MuteinWindNode.InnerText == "TRUE")
                {
                    check_mutedifwindow.Checked = true;
                }
                if (MuteinWindNode.InnerText == "FALSE")
                {
                    check_mutedifwindow.Checked = false;
                }
            }
        }

        private void check_Shadow0_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Shadow0.Checked)
            {
                check_Shadow1.Enabled = false;
                check_Shadow2.Enabled = false;
                check_Shadow3.Enabled = false;
                check_Shadow4.Enabled = false;
                check_Shadow5.Enabled = false;
            }
            else
            {
                check_Shadow1.Enabled = true;
                check_Shadow2.Enabled = true;
                check_Shadow3.Enabled = true;
                check_Shadow4.Enabled = true;
                check_Shadow5.Enabled = true;
            }
        }

        private void check_Shadow1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Shadow1.Checked)
            {
                check_Shadow0.Enabled = false;
                check_Shadow2.Enabled = false;
                check_Shadow3.Enabled = false;
                check_Shadow4.Enabled = false;
                check_Shadow5.Enabled = false;
            }
            else
            {
                check_Shadow0.Enabled = true;
                check_Shadow2.Enabled = true;
                check_Shadow3.Enabled = true;
                check_Shadow4.Enabled = true;
                check_Shadow5.Enabled = true;
            }
        }

        private void check_Shadow2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Shadow2.Checked)
            {
                check_Shadow1.Enabled = false;
                check_Shadow0.Enabled = false;
                check_Shadow3.Enabled = false;
                check_Shadow4.Enabled = false;
                check_Shadow5.Enabled = false;
            }
            else
            {
                check_Shadow1.Enabled = true;
                check_Shadow0.Enabled = true;
                check_Shadow3.Enabled = true;
                check_Shadow4.Enabled = true;
                check_Shadow5.Enabled = true;
            }
        }

        private void check_Shadow3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Shadow3.Checked)
            {
                check_Shadow1.Enabled = false;
                check_Shadow2.Enabled = false;
                check_Shadow0.Enabled = false;
                check_Shadow4.Enabled = false;
                check_Shadow5.Enabled = false;
            }
            else
            {
                check_Shadow1.Enabled = true;
                check_Shadow2.Enabled = true;
                check_Shadow0.Enabled = true;
                check_Shadow4.Enabled = true;
                check_Shadow5.Enabled = true;
            }
        }

        private void check_Shadow4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Shadow4.Checked)
            {
                check_Shadow1.Enabled = false;
                check_Shadow2.Enabled = false;
                check_Shadow3.Enabled = false;
                check_Shadow0.Enabled = false;
                check_Shadow5.Enabled = false;
            }
            else
            {
                check_Shadow1.Enabled = true;
                check_Shadow2.Enabled = true;
                check_Shadow3.Enabled = true;
                check_Shadow0.Enabled = true;
                check_Shadow5.Enabled = true;
            }
        }

        private void check_Shadow5_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Shadow5.Checked)
            {
                check_Shadow1.Enabled = false;
                check_Shadow2.Enabled = false;
                check_Shadow3.Enabled = false;
                check_Shadow4.Enabled = false;
                check_Shadow0.Enabled = false;
            }
            else
            {
                check_Shadow1.Enabled = true;
                check_Shadow2.Enabled = true;
                check_Shadow3.Enabled = true;
                check_Shadow4.Enabled = true;
                check_Shadow0.Enabled = true;
            }
        }

        private void Tex1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Tex1.Checked)
            {
                check_Tex2.Enabled = false;
                check_Tex3.Enabled = false;
            }
            else
            {
                check_Tex2.Enabled = true;
                check_Tex3.Enabled = true;
            }
        }

        private void Tex2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Tex2.Checked)
            {
                check_Tex1.Enabled = false;
                check_Tex3.Enabled = false;
            }
            else
            {
                check_Tex1.Enabled = true;
                check_Tex3.Enabled = true;
            }
        }

        private void Tex3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Tex3.Checked)
            {
                check_Tex1.Enabled = false;
                check_Tex2.Enabled = false;
            }
            else
            {
                check_Tex1.Enabled = true;
                check_Tex2.Enabled = true;
            }
        }

        private void check_Light1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Light1.Checked)
            {
                check_Light2.Enabled = false;
            }
            else
            {
                check_Light2.Enabled = true;
            }
        }

        private void check_Light2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Light2.Checked)
            {
                check_Light1.Enabled = false;
            }
            else
            {
                check_Light1.Enabled = true;
            }
        }

        private void check_Terrain1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Terrain1.Checked)
            {
                check_Terrain2.Enabled = false;
                check_Terrain3.Enabled = false;
                check_Terrain4.Enabled = false;
                check_Terrain5.Enabled = false;
            }
            else
            {
                check_Terrain2.Enabled = true;
                check_Terrain3.Enabled = true;
                check_Terrain4.Enabled = true;
                check_Terrain5.Enabled = true;
            }
        }

        private void check_Terrain2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Terrain2.Checked)
            {
                check_Terrain1.Enabled = false;
                check_Terrain3.Enabled = false;
                check_Terrain4.Enabled = false;
                check_Terrain5.Enabled = false;
            }
            else
            {
                check_Terrain1.Enabled = true;
                check_Terrain3.Enabled = true;
                check_Terrain4.Enabled = true;
                check_Terrain5.Enabled = true;
            }
        }

        private void check_Terrain3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Terrain3.Checked)
            {
                check_Terrain1.Enabled = false;
                check_Terrain2.Enabled = false;
                check_Terrain4.Enabled = false;
                check_Terrain5.Enabled = false;
            }
            else
            {
                check_Terrain1.Enabled = true;
                check_Terrain2.Enabled = true;
                check_Terrain4.Enabled = true;
                check_Terrain5.Enabled = true;
            }
        }

        private void check_Terrain4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Terrain4.Checked)
            {
                check_Terrain1.Enabled = false;
                check_Terrain2.Enabled = false;
                check_Terrain3.Enabled = false;
                check_Terrain5.Enabled = false;
            }
            else
            {
                check_Terrain1.Enabled = true;
                check_Terrain2.Enabled = true;
                check_Terrain3.Enabled = true;
                check_Terrain5.Enabled = true;
            }
        }

        private void check_Terrain5_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Terrain5.Checked)
            {
                check_Terrain1.Enabled = false;
                check_Terrain2.Enabled = false;
                check_Terrain3.Enabled = false;
                check_Terrain4.Enabled = false;
            }
            else
            {
                check_Terrain1.Enabled = true;
                check_Terrain2.Enabled = true;
                check_Terrain3.Enabled = true;
                check_Terrain4.Enabled = true;
            }
        }

        private void check_screen1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_screen1.Checked)
            {
                check_screen2.Enabled = false;
                check_screen3.Enabled = false;
            }
            else
            {
                check_screen2.Enabled = true;
                check_screen3.Enabled = true;
            }
        }

        private void check_screen2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_screen2.Checked)
            {
                check_screen1.Enabled = false;
                check_screen3.Enabled = false;
            }
            else
            {
                check_screen1.Enabled = true;
                check_screen3.Enabled = true;
            }
        }

        private void check_screen3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_screen3.Checked)
            {
                check_screen1.Enabled = false;
                check_screen2.Enabled = false;
            }
            else
            {
                check_screen1.Enabled = true;
                check_screen2.Enabled = true;
            }
        }


        private void check_minimum_CheckedChanged(object sender, EventArgs e)
        {
            if (check_minimum.Checked)
            {
                check_nmap.Enabled = false;
                check_hdr.Enabled = false;
                check_dof.Enabled = false;
                check_mb.Enabled = false;
                check_pe.Enabled = false;
                check_spao.Enabled = false;
                check_se.Enabled = false;
                check_nmap.Checked = false;
                check_hdr.Checked = false;
                check_dof.Checked = false;
                check_mb.Checked = false;
                check_pe.Checked = false;
                check_spao.Checked = false;
                check_se.Checked = false;
            }
            else
            {
                check_nmap.Enabled = true;
                check_hdr.Enabled = true;
                check_dof.Enabled = true;
                check_mb.Enabled = true;
                check_pe.Enabled = true;
                check_spao.Enabled = true;
                check_se.Enabled = true;
                check_nmap.Checked = true;
                check_hdr.Checked = true;
                check_dof.Checked = true;
                check_mb.Checked = true;
                check_pe.Checked = true;
                check_spao.Checked = true;
                check_se.Checked = true;
            }
        }

        private void check_AmVol0_CheckedChanged(object sender, EventArgs e)
        {
            if (check_AmVol0.Checked)
            {
                check_AmVol1.Enabled = false;
                check_AmVol2.Enabled = false;
                check_AmVol3.Enabled = false;
                check_AmVol4.Enabled = false;
            }
            else
            {
                check_AmVol1.Enabled = true;
                check_AmVol2.Enabled = true;
                check_AmVol3.Enabled = true;
                check_AmVol4.Enabled = true;
            }
        }

        private void check_AmVol1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_AmVol1.Checked)
            {
                check_AmVol0.Enabled = false;
                check_AmVol2.Enabled = false;
                check_AmVol3.Enabled = false;
                check_AmVol4.Enabled = false;
            }
            else
            {
                check_AmVol0.Enabled = true;
                check_AmVol2.Enabled = true;
                check_AmVol3.Enabled = true;
                check_AmVol4.Enabled = true;
            }
        }

        private void check_AmVol2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_AmVol2.Checked)
            {
                check_AmVol0.Enabled = false;
                check_AmVol1.Enabled = false;
                check_AmVol3.Enabled = false;
                check_AmVol4.Enabled = false;
            }
            else
            {
                check_AmVol0.Enabled = true;
                check_AmVol1.Enabled = true;
                check_AmVol3.Enabled = true;
                check_AmVol4.Enabled = true;
            }
        }

        private void check_AmVol3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_AmVol3.Checked)
            {
                check_AmVol0.Enabled = false;
                check_AmVol1.Enabled = false;
                check_AmVol2.Enabled = false;
                check_AmVol4.Enabled = false;
            }
            else
            {
                check_AmVol0.Enabled = true;
                check_AmVol1.Enabled = true;
                check_AmVol2.Enabled = true;
                check_AmVol4.Enabled = true;
            }
        }

        private void check_AmVol4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_AmVol4.Checked)
            {
                check_AmVol0.Enabled = false;
                check_AmVol1.Enabled = false;
                check_AmVol2.Enabled = false;
                check_AmVol3.Enabled = false;
            }
            else
            {
                check_AmVol0.Enabled = true;
                check_AmVol1.Enabled = true;
                check_AmVol2.Enabled = true;
                check_AmVol3.Enabled = true;
            }
        }

        private void check_MVol0_CheckedChanged(object sender, EventArgs e)
        {
            if (check_MVol0.Checked)
            {
                check_MVol1.Enabled = false;
                check_MVol2.Enabled = false;
                check_MVol3.Enabled = false;
                check_MVol4.Enabled = false;
            }
            else
            {
                check_MVol1.Enabled = true;
                check_MVol2.Enabled = true;
                check_MVol3.Enabled = true;
                check_MVol4.Enabled = true;
            }
        }

        private void check_MVol1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_MVol1.Checked)
            {
                check_MVol0.Enabled = false;
                check_MVol2.Enabled = false;
                check_MVol3.Enabled = false;
                check_MVol4.Enabled = false;
            }
            else
            {
                check_MVol0.Enabled = true;
                check_MVol2.Enabled = true;
                check_MVol3.Enabled = true;
                check_MVol4.Enabled = true;
            }
        }

        private void check_MVol2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_MVol2.Checked)
            {
                check_MVol0.Enabled = false;
                check_MVol1.Enabled = false;
                check_MVol3.Enabled = false;
                check_MVol4.Enabled = false;
            }
            else
            {
                check_MVol0.Enabled = true;
                check_MVol1.Enabled = true;
                check_MVol3.Enabled = true;
                check_MVol4.Enabled = true;
            }
        }

        private void check_MVol3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_MVol3.Checked)
            {
                check_MVol0.Enabled = false;
                check_MVol1.Enabled = false;
                check_MVol2.Enabled = false;
                check_MVol4.Enabled = false;
            }
            else
            {
                check_MVol0.Enabled = true;
                check_MVol1.Enabled = true;
                check_MVol2.Enabled = true;
                check_MVol4.Enabled = true;
            }
        }

        private void check_MVol4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_MVol4.Checked)
            {
                check_MVol0.Enabled = false;
                check_MVol1.Enabled = false;
                check_MVol2.Enabled = false;
                check_MVol3.Enabled = false;
            }
            else
            {
                check_MVol0.Enabled = true;
                check_MVol1.Enabled = true;
                check_MVol2.Enabled = true;
                check_MVol3.Enabled = true;
            }
        }

        private void check_BackVol0_CheckedChanged(object sender, EventArgs e)
        {
            if (check_BackVol0.Checked)
            {
                check_BackVol1.Enabled = false;
                check_BackVol2.Enabled = false;
                check_BackVol3.Enabled = false;
                check_BackVol4.Enabled = false;
            }
            else
            {
                check_BackVol1.Enabled = true;
                check_BackVol2.Enabled = true;
                check_BackVol3.Enabled = true;
                check_BackVol4.Enabled = true;
            }
        }

        private void check_BackVol1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_BackVol1.Checked)
            {
                check_BackVol0.Enabled = false;
                check_BackVol2.Enabled = false;
                check_BackVol3.Enabled = false;
                check_BackVol4.Enabled = false;
            }
            else
            {
                check_BackVol0.Enabled = true;
                check_BackVol2.Enabled = true;
                check_BackVol3.Enabled = true;
                check_BackVol4.Enabled = true;
            }
        }

        private void check_BackVol2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_BackVol2.Checked)
            {
                check_BackVol0.Enabled = false;
                check_BackVol1.Enabled = false;
                check_BackVol3.Enabled = false;
                check_BackVol4.Enabled = false;
            }
            else
            {
                check_BackVol0.Enabled = true;
                check_BackVol1.Enabled = true;
                check_BackVol3.Enabled = true;
                check_BackVol4.Enabled = true;
            }
        }

        private void check_BackVol3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_BackVol3.Checked)
            {
                check_BackVol0.Enabled = false;
                check_BackVol1.Enabled = false;
                check_BackVol2.Enabled = false;
                check_BackVol4.Enabled = false;
            }
            else
            {
                check_BackVol0.Enabled = true;
                check_BackVol1.Enabled = true;
                check_BackVol2.Enabled = true;
                check_BackVol4.Enabled = true;
            }
        }

        private void check_BackVol4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_BackVol4.Checked)
            {
                check_BackVol0.Enabled = false;
                check_BackVol1.Enabled = false;
                check_BackVol2.Enabled = false;
                check_BackVol3.Enabled = false;
            }
            else
            {
                check_BackVol0.Enabled = true;
                check_BackVol1.Enabled = true;
                check_BackVol2.Enabled = true;
                check_BackVol3.Enabled = true;
            }
        }

        private void check_EffectVol0_CheckedChanged(object sender, EventArgs e)
        {
            if (check_EffectVol0.Checked)
            {
                check_EffectVol1.Enabled = false;
                check_EffectVol2.Enabled = false;
                check_EffectVol3.Enabled = false;
                check_EffectVol4.Enabled = false;
            }
            else
            {
                check_EffectVol1.Enabled = true;
                check_EffectVol2.Enabled = true;
                check_EffectVol3.Enabled = true;
                check_EffectVol4.Enabled = true;
            }
        }

        private void check_EffectVol1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_EffectVol1.Checked)
            {
                check_EffectVol0.Enabled = false;
                check_EffectVol2.Enabled = false;
                check_EffectVol3.Enabled = false;
                check_EffectVol4.Enabled = false;
            }
            else
            {
                check_EffectVol0.Enabled = true;
                check_EffectVol2.Enabled = true;
                check_EffectVol3.Enabled = true;
                check_EffectVol4.Enabled = true;
            }
        }

        private void check_EffectVol2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_EffectVol2.Checked)
            {
                check_EffectVol0.Enabled = false;
                check_EffectVol1.Enabled = false;
                check_EffectVol3.Enabled = false;
                check_EffectVol4.Enabled = false;
            }
            else
            {
                check_EffectVol0.Enabled = true;
                check_EffectVol1.Enabled = true;
                check_EffectVol3.Enabled = true;
                check_EffectVol4.Enabled = true;
            }
        }

        private void check_EffectVol3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_EffectVol3.Checked)
            {
                check_EffectVol0.Enabled = false;
                check_EffectVol1.Enabled = false;
                check_EffectVol2.Enabled = false;
                check_EffectVol4.Enabled = false;
            }
            else
            {
                check_EffectVol0.Enabled = true;
                check_EffectVol1.Enabled = true;
                check_EffectVol2.Enabled = true;
                check_EffectVol4.Enabled = true;
            }
        }

        private void check_EffectVol4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_EffectVol4.Checked)
            {
                check_EffectVol0.Enabled = false;
                check_EffectVol1.Enabled = false;
                check_EffectVol2.Enabled = false;
                check_EffectVol3.Enabled = false;
            }
            else
            {
                check_EffectVol0.Enabled = true;
                check_EffectVol1.Enabled = true;
                check_EffectVol2.Enabled = true;
                check_EffectVol3.Enabled = true;
            }
        }


        public void save_button_Click(object sender, EventArgs e)
        {

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Raiderz\\Save\\" + ConfigFileName);
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            //Verify if exist VIDEO node
            XmlNode VideoNode = doc.SelectSingleNode("/CONFIG/VIDEO");
            if (VideoNode == null)
            {
                // If the VIDEO node does not exist, create it
                VideoNode = doc.CreateElement("VIDEO");
                doc.SelectSingleNode("/CONFIG").AppendChild(VideoNode);
            }


            // ScreenMode
            XmlNode ScreenModeNode = doc.SelectSingleNode("/CONFIG/VIDEO/SCREENMODE");
            if (ScreenModeNode == null)
            {
                ScreenModeNode = doc.CreateElement("SCREENMODE");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(ScreenModeNode);
                if (check_screen1.Checked)
                {
                    ScreenModeNode.InnerText = "0";
                }
                if (check_screen2.Checked)
                {
                    ScreenModeNode.InnerText = "1";
                }
                if (check_screen3.Checked)
                {
                    ScreenModeNode.InnerText = "2";
                }
            }
            else
            {
                 if (check_screen1.Checked)
                 {
                     ScreenModeNode.InnerText = "0";
                 }
                 if (check_screen2.Checked)
                 {
                     ScreenModeNode.InnerText = "1";
                 }
                 if (check_screen3.Checked)
                 {
                     ScreenModeNode.InnerText = "2";
                 }
            }

            // Normal Mapping
            XmlNode NormalMappingNode = doc.SelectSingleNode("/CONFIG/VIDEO/NORMALMAPPING");
            if (NormalMappingNode == null)
            {
                NormalMappingNode = doc.CreateElement("NORMALMAPPING");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(NormalMappingNode);
                if (check_nmap.Checked)
                {
                    NormalMappingNode.InnerText = "TRUE";
                }
                else
                {
                    NormalMappingNode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_nmap.Checked)
                {
                    NormalMappingNode.InnerText = "TRUE";
                }
                else
                {
                    NormalMappingNode.InnerText = "FALSE";
                }
            }

            // Dept of Field
            XmlNode DofNode = doc.SelectSingleNode("/CONFIG/VIDEO/DOF");
            if (DofNode == null)
            {
                DofNode = doc.CreateElement("DOF");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(DofNode);
                if (check_dof.Checked)
                {
                    DofNode.InnerText = "TRUE";
                }
                else
                {
                    DofNode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_dof.Checked)
                {
                    DofNode.InnerText = "TRUE";
                }
                else
                {
                    DofNode.InnerText = "FALSE";
                }
            }

            // HDR
            XmlNode HDRNode = doc.SelectSingleNode("/CONFIG/VIDEO/HDR");
            if (HDRNode == null)
            {
                HDRNode = doc.CreateElement("HDR");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(HDRNode);
                if (check_hdr.Checked)
                {
                    HDRNode.InnerText = "TRUE";
                }
                else
                {
                    HDRNode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_hdr.Checked)
                {
                    HDRNode.InnerText = "TRUE";
                }
                else
                {
                    HDRNode.InnerText = "FALSE";
                }
            }

            // Motion Blur
            XmlNode MotionBlurNode = doc.SelectSingleNode("/CONFIG/VIDEO/MOTIONBLUR");
            if (MotionBlurNode == null)
            {
                MotionBlurNode = doc.CreateElement("MOTIONBLUR");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(MotionBlurNode);
                if (check_mb.Checked)
                {
                    MotionBlurNode.InnerText = "TRUE";
                }
                else
                {
                    MotionBlurNode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_mb.Checked)
                {
                    MotionBlurNode.InnerText = "TRUE";
                }
                else
                {
                    MotionBlurNode.InnerText = "FALSE";
                }
            }

            // SOFTPARTICLE
            XmlNode SoftParticlesNode = doc.SelectSingleNode("/CONFIG/VIDEO/SOFTPARTICLE");
            if (SoftParticlesNode != null)
            {
                if (check_hdr.Checked)
                {
                    SoftParticlesNode.InnerText = "TRUE";
                }
                else
                {
                    SoftParticlesNode.InnerText = "FALSE";
                }
            }

            // Screen Space Ambient Occlusion
            XmlNode SSAONode = doc.SelectSingleNode("/CONFIG/VIDEO/SSAO");
            if (SSAONode == null)
            {
                SSAONode = doc.CreateElement("SSAO");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(SSAONode);
                if (check_spao.Checked)
                {
                    SSAONode.InnerText = "TRUE";
                }
                else
                {
                    SSAONode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_spao.Checked)
                {
                    SSAONode.InnerText = "TRUE";
                }
                else
                {
                    SSAONode.InnerText = "FALSE";
                }
            }

            // Saturation Effect
            XmlNode ColorGradingNode = doc.SelectSingleNode("/CONFIG/VIDEO/COLORGRADING");
            if (ColorGradingNode == null)
            {
                ColorGradingNode = doc.CreateElement("COLORGRADING");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(ColorGradingNode);
                if (check_se.Checked)
                {
                    ColorGradingNode.InnerText = "TRUE";
                }
                else
                {
                    ColorGradingNode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_se.Checked)
                {
                    ColorGradingNode.InnerText = "TRUE";
                }
                else
                {
                    ColorGradingNode.InnerText = "FALSE";
                }
            }

            // Resolution
            XmlNode HeightNode = doc.SelectSingleNode("/CONFIG/VIDEO/HEIGHT");
            XmlNode WidthNode = doc.SelectSingleNode("/CONFIG/VIDEO/WIDTH");
            int selectedIndex = comboResolution.SelectedIndex;
            string resolution = comboResolution.SelectedItem.ToString();
            string[] resolutionValues = resolution.Split('x');
            if (HeightNode == null)
            {
                HeightNode = doc.CreateElement("HEIGHT");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(HeightNode);
                HeightNode.InnerText = resolutionValues[1];
            }
            else
            {
                HeightNode.InnerText = resolutionValues[1];
            }
            if (WidthNode == null)
            {
                WidthNode = doc.CreateElement("WIDTH");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(WidthNode);
                WidthNode.InnerText = resolutionValues[0];
            }
            else
            {
                WidthNode.InnerText = resolutionValues[0];
            }

            // Shadow
            XmlNode ShadowNode = doc.SelectSingleNode("/CONFIG/VIDEO/SHADOW");
            if (ShadowNode == null)
            {
                ShadowNode = doc.CreateElement("COLORSHADOWGRADING");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(ShadowNode);
                if (check_Shadow0.Checked)
                {
                    ShadowNode.InnerText = "0";
                }
                if (check_Shadow1.Checked)
                {
                    ShadowNode.InnerText = "1";
                }
                if (check_Shadow2.Checked)
                {
                    ShadowNode.InnerText = "2";
                }
                if (check_Shadow3.Checked)
                {
                    ShadowNode.InnerText = "3";
                }
                if (check_Shadow4.Checked)
                {
                    ShadowNode.InnerText = "4";
                }
                if (check_Shadow5.Checked)
                {
                    ShadowNode.InnerText = "5";
                }
            }
            else
            {
                if (check_Shadow0.Checked)
                {
                    ShadowNode.InnerText = "0";
                }
                if (check_Shadow1.Checked)
                {
                    ShadowNode.InnerText = "1";
                }
                if (check_Shadow2.Checked)
                {
                    ShadowNode.InnerText = "2";
                }
                if (check_Shadow3.Checked)
                {
                    ShadowNode.InnerText = "3";
                }
                if (check_Shadow4.Checked)
                {
                    ShadowNode.InnerText = "4";
                }
                if (check_Shadow5.Checked)
                {
                    ShadowNode.InnerText = "5";
                }
            }

            // Light Source
            XmlNode LightSourceNode = doc.SelectSingleNode("/CONFIG/VIDEO/LIGHTING");
            if (LightSourceNode == null)
            {
                LightSourceNode = doc.CreateElement("LIGHTING");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(LightSourceNode);
                if (check_Light1.Checked)
                {
                    LightSourceNode.InnerText = "1";
                }
                if (check_Light2.Checked)
                {
                    LightSourceNode.InnerText = "2";
                }
            }
            else
            {
                if (check_Light1.Checked)
                {
                    LightSourceNode.InnerText = "1";
                }
                if (check_Light2.Checked)
                {
                    LightSourceNode.InnerText = "2";
                }
            }

            // MinPerformance
            XmlNode MinPerformanceNode = doc.SelectSingleNode("/CONFIG/VIDEO/MINPERFORMANCE");
            if (MinPerformanceNode == null)
            {
                MinPerformanceNode = doc.CreateElement("MINPERFORMANCE");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(MinPerformanceNode);
                if (check_minimum.Checked)
                {
                    MinPerformanceNode.InnerText = "TRUE";
                }
                else
                {
                    MinPerformanceNode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_minimum.Checked)
                {
                    MinPerformanceNode.InnerText = "TRUE";
                }
                else
                {
                    MinPerformanceNode.InnerText = "FALSE";
                }
            }

            // TexResolution
            XmlNode TexResolutionNode = doc.SelectSingleNode("/CONFIG/VIDEO/TEXTUREREDUCTION");
            if (TexResolutionNode == null)
            {
                TexResolutionNode = doc.CreateElement("TEXTUREREDUCTION");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(TexResolutionNode);
                if (check_Tex1.Checked)
                {
                    TexResolutionNode.InnerText = "2";
                }
                if (check_Tex2.Checked)
                {
                    TexResolutionNode.InnerText = "1";
                }
                if (check_Tex3.Checked)
                {
                    TexResolutionNode.InnerText = "0";
                }
            }
            else
            {
                if (check_Tex1.Checked)
                {
                    TexResolutionNode.InnerText = "2";
                }
                if (check_Tex2.Checked)
                {
                    TexResolutionNode.InnerText = "1";
                }
                if (check_Tex3.Checked)
                {
                    TexResolutionNode.InnerText = "0";
                }
            }

            // LodFactor
            XmlNode LodFactorNode = doc.SelectSingleNode("/CONFIG/VIDEO/LODFACTOR");
            XmlNode OBJRangeNode = doc.SelectSingleNode("/CONFIG/VIDEO/GRNDOBJVISIBLERANGE");
            if (LodFactorNode == null && OBJRangeNode == null)
            {
                LodFactorNode = doc.CreateElement("LODFACTOR");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(LodFactorNode);
                OBJRangeNode = doc.CreateElement("GRNDOBJVISIBLERANGE");
                doc.SelectSingleNode("/CONFIG/VIDEO").AppendChild(OBJRangeNode);
                if (check_Terrain1.Checked)
                {
                    LodFactorNode.InnerText = "2.00";
                    OBJRangeNode.InnerText = "1000";
                }
                if (check_Terrain2.Checked)
                {
                    LodFactorNode.InnerText = "1.75";
                    OBJRangeNode.InnerText = "3000";
                }
                if (check_Terrain3.Checked)
                {
                    LodFactorNode.InnerText = "1.50";
                    OBJRangeNode.InnerText = "5000";
                }
                if (check_Terrain4.Checked)
                {
                    LodFactorNode.InnerText = "1.25";
                    OBJRangeNode.InnerText = "7000";
                }
                if (check_Terrain5.Checked)
                {
                    LodFactorNode.InnerText = "1.00";
                    OBJRangeNode.InnerText = "9000";
                }
            }
            else
            {
                if (check_Terrain1.Checked)
                {
                    LodFactorNode.InnerText = "2.00";
                    OBJRangeNode.InnerText = "1000";
                }
                if (check_Terrain2.Checked)
                {
                    LodFactorNode.InnerText = "1.75";
                    OBJRangeNode.InnerText = "3000";
                }
                if (check_Terrain3.Checked)
                {
                    LodFactorNode.InnerText = "1.50";
                    OBJRangeNode.InnerText = "5000";
                }
                if (check_Terrain4.Checked)
                {
                    LodFactorNode.InnerText = "1.25";
                    OBJRangeNode.InnerText = "7000";
                }
                if (check_Terrain5.Checked)
                {
                    LodFactorNode.InnerText = "1.00";
                    OBJRangeNode.InnerText = "9000";
                }
            }

            //Verify if exist AUDIO node
            XmlNode AudioNode = doc.SelectSingleNode("/CONFIG/AUDIO");
            if (AudioNode == null)
            {
                // If the AUDIO node does not exist, create it
                AudioNode = doc.CreateElement("AUDIO");
                doc.SelectSingleNode("/CONFIG").AppendChild(AudioNode);
            }

            // AmbientSound
            XmlNode AmbientSoundNode = doc.SelectSingleNode("/CONFIG/AUDIO/GENERICVOLUME");
            if (AmbientSoundNode == null)
            {
                AmbientSoundNode = doc.CreateElement("GENERICVOLUME");
                doc.SelectSingleNode("/CONFIG/AUDIO").AppendChild(AmbientSoundNode);
                if (check_AmVol0.Checked)
                {
                    AmbientSoundNode.InnerText = "0.00";
                }
                if (check_AmVol1.Checked)
                {
                    AmbientSoundNode.InnerText = "0.25";
                }
                if (check_AmVol2.Checked)
                {
                    AmbientSoundNode.InnerText = "0.50";
                }
                if (check_AmVol3.Checked)
                {
                    AmbientSoundNode.InnerText = "0.75";
                }
                if (check_AmVol4.Checked)
                {
                    AmbientSoundNode.InnerText = "1.00";
                }
            }
            else
            {
                if (check_AmVol0.Checked)
                {
                    AmbientSoundNode.InnerText = "0.00";
                }
                if (check_AmVol1.Checked)
                {
                    AmbientSoundNode.InnerText = "0.25";
                }
                if (check_AmVol2.Checked)
                {
                    AmbientSoundNode.InnerText = "0.50";
                }
                if (check_AmVol3.Checked)
                {
                    AmbientSoundNode.InnerText = "0.75";
                }
                if (check_AmVol4.Checked)
                {
                    AmbientSoundNode.InnerText = "1.00";
                }
            }

            // MainSound
            XmlNode MainSoundNode = doc.SelectSingleNode("/CONFIG/AUDIO/MASTERVOLUME");
            if (MainSoundNode == null)
            {
                MainSoundNode = doc.CreateElement("MASTERVOLUME");
                doc.SelectSingleNode("/CONFIG/AUDIO").AppendChild(MainSoundNode);
                if (check_MVol0.Checked)
                {
                    MainSoundNode.InnerText = "0.00";
                }
                if (check_MVol1.Checked)
                {
                    MainSoundNode.InnerText = "0.25";
                }
                if (check_MVol2.Checked)
                {
                    MainSoundNode.InnerText = "0.50";
                }
                if (check_MVol3.Checked)
                {
                    MainSoundNode.InnerText = "0.75";
                }
                if (check_MVol4.Checked)
                {
                    MainSoundNode.InnerText = "1.00";
                }
            }
            else
            {
                if (check_MVol0.Checked)
                {
                    MainSoundNode.InnerText = "0.00";
                }
                if (check_MVol1.Checked)
                {
                    MainSoundNode.InnerText = "0.25";
                }
                if (check_MVol2.Checked)
                {
                    MainSoundNode.InnerText = "0.50";
                }
                if (check_MVol3.Checked)
                {
                    MainSoundNode.InnerText = "0.75";
                }
                if (check_MVol4.Checked)
                {
                    MainSoundNode.InnerText = "1.00";
                }
            }

            // BackSound
            XmlNode BackSoundNode = doc.SelectSingleNode("/CONFIG/AUDIO/BGMVOLUME");
            if (BackSoundNode == null)
            {
                BackSoundNode = doc.CreateElement("BGMVOLUME");
                doc.SelectSingleNode("/CONFIG/AUDIO").AppendChild(BackSoundNode);
                if (check_BackVol0.Checked)
                {
                    BackSoundNode.InnerText = "0.00";
                }
                if (check_BackVol1.Checked)
                {
                    BackSoundNode.InnerText = "0.25";
                }
                if (check_BackVol2.Checked)
                {
                    BackSoundNode.InnerText = "0.50";
                }
                if (check_BackVol3.Checked)
                {
                    BackSoundNode.InnerText = "0.75";
                }
                if (check_BackVol4.Checked)
                {
                    BackSoundNode.InnerText = "1.00";
                }
            }
            else
            {
                if (check_BackVol0.Checked)
                {
                    BackSoundNode.InnerText = "0.00";
                }
                if (check_BackVol1.Checked)
                {
                    BackSoundNode.InnerText = "0.25";
                }
                if (check_BackVol2.Checked)
                {
                    BackSoundNode.InnerText = "0.50";
                }
                if (check_BackVol3.Checked)
                {
                    BackSoundNode.InnerText = "0.75";
                }
                if (check_BackVol4.Checked)
                {
                    BackSoundNode.InnerText = "1.00";
                }
            }

            // EffectSound
            XmlNode EffectSoundNode = doc.SelectSingleNode("/CONFIG/AUDIO/EFFECTVOLUME");
            if (EffectSoundNode == null)
            {
                EffectSoundNode = doc.CreateElement("EFFECTVOLUME");
                doc.SelectSingleNode("/CONFIG/AUDIO").AppendChild(EffectSoundNode);
                if (check_EffectVol0.Checked)
                {
                    EffectSoundNode.InnerText = "0.00";
                }
                if (check_EffectVol1.Checked)
                {
                    EffectSoundNode.InnerText = "0.25";
                }
                if (check_EffectVol2.Checked)
                {
                    EffectSoundNode.InnerText = "0.50";
                }
                if (check_EffectVol3.Checked)
                {
                    EffectSoundNode.InnerText = "0.75";
                }
                if (check_EffectVol4.Checked)
                {
                    EffectSoundNode.InnerText = "1.00";
                }
            }
            else
            {
                if (check_EffectVol0.Checked)
                {
                    EffectSoundNode.InnerText = "0.00";
                }
                if (check_EffectVol1.Checked)
                {
                    EffectSoundNode.InnerText = "0.25";
                }
                if (check_EffectVol2.Checked)
                {
                    EffectSoundNode.InnerText = "0.50";
                }
                if (check_EffectVol3.Checked)
                {
                    EffectSoundNode.InnerText = "0.75";
                }
                if (check_EffectVol4.Checked)
                {
                    EffectSoundNode.InnerText = "1.00";
                }
            }

            // Hardacceleration
            XmlNode HardAccelNode = doc.SelectSingleNode("/CONFIG/AUDIO/HARDWAREACC");
            if (HardAccelNode == null)
            {
                HardAccelNode = doc.CreateElement("HARDWAREACC");
                doc.SelectSingleNode("/CONFIG/AUDIO").AppendChild(HardAccelNode);
                if (check_hardacce.Checked)
                {
                    HardAccelNode.InnerText = "TRUE";
                }
                else
                {
                    HardAccelNode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_hardacce.Checked)
                {
                    HardAccelNode.InnerText = "TRUE";
                }
                else
                {
                    HardAccelNode.InnerText = "FALSE";
                }
            }

            // MuteInOtherWindow
            XmlNode MuteinWindNode = doc.SelectSingleNode("/CONFIG/AUDIO/INACTIVESOUND");
            if (MuteinWindNode == null)
            {
                MuteinWindNode = doc.CreateElement("INACTIVESOUND");
                doc.SelectSingleNode("/CONFIG/AUDIO").AppendChild(MuteinWindNode);
                if (check_mutedifwindow.Checked)
                {
                    MuteinWindNode.InnerText = "TRUE";
                }
                else
                {
                    MuteinWindNode.InnerText = "FALSE";
                }
            }
            else
            {
                if (check_mutedifwindow.Checked)
                {
                    MuteinWindNode.InnerText = "TRUE";
                }
                else
                {
                    MuteinWindNode.InnerText = "FALSE";
                }
            }

            doc.Save(filePath);
            MessageBox.Show("All configurations saved!");
        }
    }
}






