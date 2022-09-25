FROM ubuntu:22.04

RUN apt update && \
    apt install -y --no-install-recommends \
    nginx curl vim nano net-tools zip unzip \
    jq dnsutils iputils-ping && \
    apt clean && \
    rm -rf /var/lib/apt/lists

COPY index.html /var/www/html/index.html
ADD web.sh /opt

EXPOSE 80

CMD ["/bin/bash", "-c", "/opt/web.sh"]
#CMD ["/bin/bash"]
