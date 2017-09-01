## Run

### heartbeat.conf

```
$ docker run -v //E/src/poc-log-dfds/logstash/heartbeat/pipeline/:/usr/share/logstash/pipeline/ -v //E/src/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it docker.elastic.co/logstash/logstash:5.5.2
```

### jdbc.conf

```
$ docker run -v //E/src/poc-log-dfds/logstash/jdbc/sqljdbc42.jar:/usr/share/logstash/jdbc_driver/sqljdbc42.jar -v //E/src/poc-log-dfds/logstash/jdbc/pipeline/:/usr/share/logstash/pipeline/ -v //E/src/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it --link es:elasticsearch docker.elastic.co/logstash/logstash:5.5.2
```

## Single instance

### udp.conf

```
$ docker run -v //E/src/poc-log-dfds/logstash/udp/single_wo_template/pipeline/:/usr/share/logstash/pipeline/ -v //E/src/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it --link es:elasticsearch -p 8080:8080/udp docker.elastic.co/logstash/logstash:5.5.2
```

### udp.conf with custom template

```
$ docker run -v //E/src/poc-log-dfds/logstash/udp/single_w_template/template/custom_template.json:/usr/share/logstash/config/custom_template.json -v //E/src/poc-log-dfds/logstash/udp/single_w_template/pipeline/:/usr/share/logstash/pipeline/ -v //E/src/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it --link es:elasticsearch -p 8080:8080/udp docker.elastic.co/logstash/logstash:5.5.2
```

## multiple instances

### udp.conf local->forwarder

```
$ docker run -v //E/src/poc-log-dfds/logstash/udp/multiple/pipeline_1/:/usr/share/logstash/pipeline/ -v //E/src/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls-tcp_1 --rm -it --link ls-tcp_2:tcp-in-ls -p 8080:8080/udp docker.elastic.co/logstash/logstash:5.5.2
```

### udp.conf forwarder->elasticsearch

```
$ docker run -v //E/src/poc-log-dfds/logstash/udp/multiple/pipeline_2/:/usr/share/logstash/pipeline/ -v //E/src/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml -v //E/src/poc-log-dfds/logstash/udp/multiple/template/custom_template.json:/usr/share/logstash/config/custom_template.json --name ls-tcp_2 --link es:elasticsearch --rm -it docker.elastic.co/logstash/logstash:5.5.2
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



