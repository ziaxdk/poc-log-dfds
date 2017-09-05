## Run

### Local PC

```
$ docker run -d -v //E/src/poc-log-dfds/kibana/settings/kibana.yml:/usr/share/kibana/config/kibana.yml --link es:elasticsearch --name kb --rm -it -p 5601:5601 docker.elastic.co/kibana/kibana:5.5.2
```

### Azure

```
$ docker run -d -v //home/keols/poc-log-dfds/kibana/settings/kibana_azure.yml:/usr/share/kibana/config/kibana.yml --link es:elasticsearch --name kb --rm -it -p 5601:5601 docker.elastic.co/kibana/kibana:5.5.2
```

## Follow logs

```
$ docker logs -f kb
```

## Pull images

```
$ docker pull docker.elastic.co/kibana/kibana:5.5.2
```
