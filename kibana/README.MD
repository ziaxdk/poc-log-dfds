## Run

```
$ docker run -d -v //E/src/es/kibana/settings/kibana.yml:/usr/share/kibana/config/kibana.yml --link es:elasticsearch --name kb --rm -it -p 5601:5601 docker.elastic.co/kibana/kibana:5.5.2
```

## Follow logs

```
$ docker logs -f kb
```

## Pull images

```
$ docker pull docker.elastic.co/kibana/kibana:5.5.2
```
