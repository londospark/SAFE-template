#r "paket: groupref build //"
#load "./.fake/build.fsx/intellisense.fsx"

#r "netstandard"

open Fake.Core

Target.initEnvironment ()

Target.create "Clean" SAFE.Core.clean
Target.create "InstallClient" SAFE.Core.installClient
Target.create "Build" SAFE.Core.build
Target.create "Bundle" SAFE.Core.bundle
Target.create "Deploy" SAFE.Core.deploy
Target.create "Run" SAFE.Core.run

open Fake.Core.TargetOperators

"Clean"
    ==> "InstallClient"
    ==> "Build"
    ==> "Bundle"
    ==> "Deploy"

"Clean"
    ==> "InstallClient"
    ==> "Run"

Target.runOrDefaultWithArguments "Build"