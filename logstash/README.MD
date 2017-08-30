## Run

### heartbeat.conf

```
$ docker run -v //E/src/es/logstash/pipelines/heartbeat/:/usr/share/logstash/pipeline/ -v //E/src/es/logstash/settings/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it docker.elastic.co/logstash/logstash:5.5.2
```

### jdbc.conf

```
$ docker run -v //E/src/es/logstash/jdbc/sqljdbc42.jar:/usr/share/logstash/jdbc_driver/sqljdbc42.jar -v //E/src/es/logstash/pipelines/jdbc/:/usr/share/logstash/pipeline/ -v //E/src/es/logstash/settings/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it --link es:elasticsearch docker.elastic.co/logstash/logstash:5.5.2
```

### udp.conf

```
$ docker run -v //E/src/es/logstash/pipelines/udp/:/usr/share/logstash/pipeline/ -v //E/src/es/logstash/settings/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it --link es:elasticsearch -p 8080:8080/udp docker.elastic.co/logstash/logstash:5.5.2
```

### udp.conf with custom template

```
$ docker run -v //E/src/es/logstash/udp/template/custom_template.json:/usr/share/logstash/config/custom_template.json -v //E/src/es/logstash/udp/pipeline:/usr/share/logstash/pipeline/ -v //E/src/es/logstash/settings/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it --link es:elasticsearch -p 8080:8080/udp docker.elastic.co/logstash/logstash:5.5.2
```

## Pull images

```
$ docker pull docker.elastic.co/logstash/logstash:5.5.2
```

## JDBC Setup

[https://stackoverflow.com/questions/31674583/logstash-sql-server-data-import](https://stackoverflow.com/questions/31674583/logstash-sql-server-data-import)

[https://docs.microsoft.com/en-us/sql/connect/jdbc/download-microsoft-jdbc-driver-for-sql-server](https://docs.microsoft.com/en-us/sql/connect/jdbc/download-microsoft-jdbc-driver-for-sql-server)

## Follow logs

```
$ docker logs -f ls
```



