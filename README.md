# Install_istio

## Download istioctl

Execute the next commands to install **istioclt**
```
cd ~
curl -L https://istio.io/downloadIstio | sh -
```
This will download and configure the PATH environment variable and add istioctl as a command in the terminal. If the command is not recognized, you need to add the path:
```
vim ~/.zshrc
or
vim ~/.bashrc
and add:
export PATH=$PATH:$HOME/istioctl-1.xx.xx/bin
```

## Install the istio CRD and Ingress

Lets suppose that you had downloaded the versión istioctl-1.11.4. We need to execute the charts insisde de installation folder

```
cd ~/istioctl-1.11.4/manifests
```
Then execute the next command to create the **istio-system** namespace

```
kubectl create namespace istio-system
```

Create the istio base deployment:
```
helm install istio-base charts/base -n istio-system
```
After that deploy the istio service discovery **istiod** chart
```
helm install istiod charts/istio-control/istio-discovery -n istio-system
```

Install the application ingress from istio:

```
kubectl create namespace istio-ingress
kubectl label namespace istio-ingress istio-injection=enabled
helm install istio-ingress charts/gateways/istio-ingress -n istio-ingress --wait
```

Validate the isntallation:

```
kubectl -n istio-ingress  get svc
```

Optional steps can be found in [Istio](https://istio.io/latest/docs/setup/install/helm/)


## Install Phometheus and Grafana

This next steps are only a base to configurate Prometheus and grafana.
Install Prometheus:
```
kubectl apply -f https://raw.githubusercontent.com/istio/istio/release-1.11/samples/addons/prometheus.yaml
```
Install grafana
```
https://istio.io/latest/docs/ops/integrations/grafana/

kubectl apply -f https://raw.githubusercontent.com/istio/istio/release-1.12/samples/addons/grafana.yaml
```

Install Kiali

```
kubectl apply -f https://raw.githubusercontent.com/istio/istio/release-1.12/samples/addons/kiali.yaml

```

# Initial deployment

Create namespace

```
kubectl create namespace test-services
kubectl label namespace test-services istio-injection=enabled
```

Change directory:

```
cd 4-Load-services
```

Create the backend and frontend deployment

```
kubectl apply -f backend.yml
kubectl apply -f frontend.yml
```

Wait for the creation and then create the  gateway and virtual service resources:

```
kubectl apply -f gateway.yml
kubectl apply -f virtualService.yml
```

