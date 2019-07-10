cd ../src/UnityTipsMuseum/
dotnet publish -c release
xcopy "bin/Release/netstandard2.0/publish/UnityTipsMuseum/dist" "../../../giacomelli.github.io-jekyll/src/apps/unitytips-museum" /E /Y
rm -rf bin/

cd ../../tools
xcopy "jekyll-files" "../../giacomelli.github.io-jekyll/src/apps/unitytips-museum" /E /Y 
