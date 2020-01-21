#!/bin/sh -l

echo "Run InferSharp translation..."      
sudo dotnet /app/Cilsil/bin/Debug/netcoreapp2.2/Cilsil.dll translate $1 --outcfg cfg.json --outtenv tenv.json
sudo infer capture
sudo mkdir infer-out/captured
echo "Run Infer..."
sudo infer analyzejson --debug --cfg-json cfg.json --tenv-json tenv.json
sudo chmod -R 777 infer-out/

var=$( cat -s infer-out/bugs.txt | sed -E -e '/ANALYSIS_STOP|Bad_footprint|Missing_fld|PRECONDITION_NOT_MET|Assert_failure|CLASS_CAST_EXCEPTION|Abduction_case_not_implemented|Found.[0-9]+.issues|Summary.of.the.report/,/^[[:space:]]*$/d' )
echo ::set-output name=results::$var