﻿using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;

namespace testSample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var application = Application.Launch("C:\\Program Files (x86)\\Windows Media Player\\wmplayer.exe");
            var windows = application.GetWindow("Windows Media Player", InitializeOption.NoCache);

            var playlistNode = windows.Get<TreeNode>(SearchCriteria.ByText("Playlists"));
            playlistNode.Expand();
            var automationPlaylist = windows.Get<TreeNode>(SearchCriteria.ByText("Automation"));
            automationPlaylist.DoubleClick();

            var playPauseButton = windows.Get<Button>(SearchCriteria.ByText("Pause"));
            Thread.Sleep(2000);
            Assert.AreEqual(playPauseButton.Text, "Pause");
            playPauseButton.Click();
            Assert.AreEqual(playPauseButton.Text, "Play");

            application.Close();
        }
    }
}