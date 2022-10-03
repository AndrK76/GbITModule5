FROM ubuntu:18.04

RUN apt update && \
    apt install -y --no-install-recommends \
    nginx curl vim nano net-tools zip unzip \
    jq dnsutils iputils-ping && \
    apt clean && \
    rm -rf /var/lib/apt/lists

ADD ../../../../consul_1.4.4_linux_amd64.zip /tmp/consul.zip
RUN cd /bin && unzip /tmp/consul.zip && chmod +x /bin/consul && rm /tmp/consul.zip

COPY index.html /var/www/html/index.html
ADD web.sh /opt

RUN mkdir -p  /data/db /etc/consul.d
ADD ./consul /etc/consul.d

EXPOSE 80

CMD ["/bin/bash", "-c", "/opt/web.sh"]