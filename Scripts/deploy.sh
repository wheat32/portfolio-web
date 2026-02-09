#!/bin/bash

cd /home/nick/Documents/GitHub/portfolio-web

echo "Resetting local changes..."
git reset --hard HEAD

echo "Pulling latest code..."
git pull

echo "Publishing solution..."
dotnet publish src/Portfolio/Portfolio.csproj -c Release

echo "Stopping service..."
sudo systemctl stop portfolio-web

echo "Deploying web app"
sudo rm -rf /opt/portfolio
sudo mkdir -p /opt/portfolio
sudo cp -r ./src/Portfolio/bin/Release/net10.0/publish/* /opt/portfolio

echo "Starting services..."
sudo systemctl start portfolio-web

echo "Redeployment complete."
