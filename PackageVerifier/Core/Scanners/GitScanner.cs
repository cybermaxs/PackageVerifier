using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.VersionControl.Client;
using Octokit;
using PackageVerifier.Core;
using PackageVerifier.Models;
using PackageVerifier.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PackageVerifier.Core.Scanners
{
    class GitScanner : BaseScanner, IScanner
    {
        public GitScanner(ILogger logger, IAnalytics analytics, Settings settings)
            : base(logger, analytics, settings)
        {

        }

        public async Task ScanAsync()
        {
            Uri githubUri = new Uri(this.settings.Home);

            // TODO
            //var github = new GitHubClient(new ProductHeaderValue("PackageVerifier"));
            //github.Search.SearchCode(new SearchCodeRequest())
            //var user = await github.User.Get("half-ogre");
            //Console.WriteLine(user.Followers + " folks love the half ogre!");

        }
    }
}
