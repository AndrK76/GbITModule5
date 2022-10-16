FROM ubuntu:22.04

RUN apt update && \
    apt-get install -y dotnet6 ca-certificates && \
    apt-get install -y net-tools

RUN mkdir /opt/app && \
    mkdir /opt/app/src && \
    mkdir /opt/app/release

WORKDIR src
COPY src /opt/app/src 

RUN cd /opt/app/src && \
    dotnet publish -c Release -o ../release

RUN cp /opt/app/src/person.xml /opt/app/release/person.xml && \
    cp /opt/app/src/person.json /opt/app/release/person.json && \
    cp /opt/app/src/app.sh /opt/app/app.sh && \
    chmod a+x /opt/app/app.sh
 
EXPOSE 80
EXPOSE 5000
EXPOSE 5001

CMD ["bash", "-c", "/opt/app/app.sh"] 
#ENTRYPOINT ["dotnet", "/opt/app/release/WebApplicationCh06_04.dll"]