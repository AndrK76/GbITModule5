#!/bin/bash

sed -i -e 's/WEB_NODE/'"$NODE"'/g' /var/www/html/index.html
sed -i -e 's/IP_ADDRESS/'"$PRIVATE_IP_ADDRESS"'/g' /var/www/html/index.html

echo "Starting Nginx..."
nginx -g 'daemon off;' &

echo "Starting Consul..."
consul agent -bind $PRIVATE_IP_ADDRESS \
    -advertise $PRIVATE_IP_ADDRESS \
    -join consul_server \
    -node $NODE \
    -dns-port 53 \
    -data-dir /data \
    -config-dir /etc/consul.d \
    -enable-local-script-checks