using System.Collections;
using System.Diagnostics;

namespace DragAndDrop
{
    public partial class mainForm : Form
    {

        string path = $"{Environment.CurrentDirectory}\\user\\mods";
        string bepinpath = $"{Environment.CurrentDirectory}\\BepInEx\\plugins";
        string listmods = "";
        int i = 0;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            lbldetected.Text = $"Detected server: {Path.GetFileName(Environment.CurrentDirectory)}";
        }

        private void CopyAll(string source, string destination)
        {
            var dir = new DirectoryInfo(source);
            var dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + source);
            }

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var temppath = Path.Combine(destination, file.Name);
                file.CopyTo(temppath, false);
            }

            if (dirs.Length == 0) return;
            foreach (var subdir in dirs)
            {
                var temppath = Path.Combine(destination, subdir.Name);
                CopyAll(subdir.FullName, temppath);
            }
        }

        private void lblplaceholder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void lblplaceholder_DragDrop(object sender, DragEventArgs e)
        {
            string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop);
            string[] mods = new string[0];

            foreach (string folder in folders)
            {
                string newFolder = Path.Combine(path, Path.GetFileName(folder));
                string newBepinFolder = Path.Combine(bepinpath, Path.GetFileName(folder));

                try
                {
                    if (File.GetAttributes(folder).HasFlag(FileAttributes.Directory))
                    {
                        // Mod is a folder

                        if (!File.Exists($"{folder}\\package.json"))
                        {

                            if (!Directory.Exists(newBepinFolder))
                                Directory.CreateDirectory(newBepinFolder);
                            CopyAll(folder, newBepinFolder);
                            Directory.Delete(folder, true);
                            Array.Resize(ref mods, mods.Length + 1);
                            mods[mods.Length - 1] = Path.GetFileName(folder);
                            listmods += $"-> {Path.GetFileName(folder)}{Environment.NewLine}";
                            i++;
                        } else
                        {

                            if (!Directory.Exists(newFolder))
                                Directory.CreateDirectory(newFolder);
                            CopyAll(folder, newFolder);
                            Directory.Delete(folder, true);
                            Array.Resize(ref mods, mods.Length + 1);
                            mods[mods.Length - 1] = Path.GetFileName(folder);
                            listmods += $"-> {Path.GetFileName(folder)}{Environment.NewLine}";
                            i++;
                        }

                    } else
                    {
                        // Mod is a file
                        if (Path.GetExtension(folder).ToLower() == ".dll")
                        {

                            File.Copy(folder, newBepinFolder);
                            Array.Resize(ref mods, mods.Length + 1);
                            mods[mods.Length - 1] = Path.GetFileName(folder);
                            listmods += $"-> {Path.GetFileName(folder)}{Environment.NewLine}";
                            i++;
                            File.Delete(folder);
                        }
                    }

                }
                catch (Exception err)
                {
                    Debug.WriteLine($"ERROR: {err.Message.ToString()}");
                }
            }

            successtimer.Start();
        }

        private void successtimer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(10);
            if (progressBar.Value != 30)
            {
                lblplaceholder.Text = $"Drag and drop your mod folder(s) here\n\nSuccessfully transferred {i} mods.\n{listmods}";
                progressBar.Value++;
            } else
            {
                
                lblplaceholder.Text = $"Drag and drop your mod folder(s) here";
                successtimer.Stop();
                progressBar.Value = 0;
            }
        }
    }
}