FROM ubuntu:18.04

RUN apt update && \
    apt install -y --no-install-recommends \
    bash curl nano net-tools zip unzip \
    jq dnsutils iputils-ping consul && \
    apt clean && \
    rm -rf /var/lib/apt/lists

# Consul ports
EXPOSE 8300 8301 8302 8400 8500

ADD consul_server.sh /opt
RUN mkdir -p /data
VOLUME /data

CMD ["/opt/consul_server.sh"]