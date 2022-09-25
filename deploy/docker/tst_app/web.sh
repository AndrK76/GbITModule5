#!/bin/bash

#echo "NODE=" $NODE
#echo "PRIVATE_IP_ADDRESS=" $PRIVATE_IP_ADDRESS

export PRIVATE_IP=`ifconfig eth0 | grep inet | awk '{print $2}'`
#echo "PRIVATE_IP=" $PRIVATE_IP

sed -i -e 's/WEB_NODE/'"$NODE"'/g' /var/www/html/index.html
sed -i -e 's/IP_ADDRESS/'"$PRIVATE_IP"'/g' /var/www/html/index.html

echo "Starting Nginx..."
nginx -g 'daemon off;' 
