FROM ubuntu:20.04

RUN apt update && \
    apt install -y --no-install-recommends \
    nginx curl vim nano net-tools zip unzip \
    jq dnsutils iputils-ping mc dos2unix && \
    apt clean && \
    rm -rf /var/lib/apt/lists

COPY test.conf  /tmp/test.conf
COPY index.html /tmp/index.html
COPY index2.html /tmp/index2.html

EXPOSE 80
EXPOSE 8081

