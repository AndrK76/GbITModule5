FROM ubuntu:18.04

RUN apt update && \
    apt install -y --no-install-recommends \
    nginx curl vim nano net-tools zip unzip \
    jq dnsutils iputils-ping consul && \
    apt clean && \
    rm -rf /var/lib/apt/lists

COPY index.html /var/www/html/index.html
ADD web.sh /opt

###RUN mkdir -p  /data/db /etc/consul.d
###ADD ./consul /etc/consul.d
RUN mkdir -p  /data/db

EXPOSE 80

CMD ["/bin/bash", "-c", "/opt/web.sh"]