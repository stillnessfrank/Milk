///////////////////////////////////////////////////////////////////////////////
// Material viewer Extension
// by Philippe Leefsma, October 2014
//
///////////////////////////////////////////////////////////////////////////////
AutodeskNamespace("Autodesk.ADN.Viewing.Extension");

Autodesk.ADN.Viewing.Extension.Material = function (viewer, options) {

  // base constructor
  Autodesk.Viewing.Extension.call(this, viewer, options);

  ///////////////////////////////////////////////////////////////////////////
  // generates random guid
  //
  ///////////////////////////////////////////////////////////////////////////
  function guid () {

    var d = new Date().getTime();

    var guid = 'xxxx-xxxx-xxxx-xxxx'.replace(
      /[xy]/g,
      function (c) {
        var r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        return (c == 'x' ? r : (r & 0x7 | 0x8)).toString(16);
      });

    return guid;
  };

  ///////////////////////////////////////////////////////////////////////////
  // Private members
  //
  ///////////////////////////////////////////////////////////////////////////
  var _material = null;

  var _textures = [];
  var _viewer = viewer;
  var _self = this;

  var colorPicker = guid();

  var texture1 = guid();
  var texture2 = guid();
  var texture3 = guid();

  ///////////////////////////////////////////////////////////////////////////
  // load callback
  //
  ///////////////////////////////////////////////////////////////////////////
  _self.load = function () {

    var dependencies = [
      "js/Material/spectrum.js"
    ];

    $('<link/>', {
      rel: 'stylesheet',
      type: 'text/css',
      href: 'js/Material/spectrum.css'
    }).appendTo('head');

    require(dependencies, function() {

      _material = addMaterial(0xf571d6);

      _textures.push(addTexMaterial("js/Material/wood.jpg"));
      _textures.push(addTexMaterial("js/Material/steel.jpg"));
      _textures.push(addTexMaterial("js/Material/brick.jpg"));
      console.log('My extension is loaded');
      //viewer.addEventListener(
      //  Autodesk.Viewing.SELECTION_CHANGED_EVENT,
      //  onItemSelected
      //  );
      viewer.addEventListener(
            Autodesk.Viewing.GEOMETRY_LOADED_EVENT,
            function (event) {
                var color = "#FF0000"
                var colorHexStr = parseInt(color.toString().replace('#', '0x'), 16);
                _material = addMaterial(colorHexStr);
                //setMaterial(13555, _material);

            });
      console.log("Autodesk.ADN.Viewing.Extension.Material loaded");
    });

    return true;
  };

  ///////////////////////////////////////////////////////////////////////////
  // unload callback
  //
  ///////////////////////////////////////////////////////////////////////////
  _self.unload = function () {

    console.log("Autodesk.ADN.Viewing.Extension.Material unloaded");

    //viewer.removeEventListener(
    //  Autodesk.Viewing.SELECTION_CHANGED_EVENT,
    //  onItemSelected);
    //$('#' + colorPicker).remove();

    //$('#' + texture1).remove();
    //$('#' + texture2).remove();
    //$('#' + texture3).remove();

    return true;
  };

  ///////////////////////////////////////////////////////////////////////////
  // item selected callback
  //
  ///////////////////////////////////////////////////////////////////////////
  function onItemSelected(event) {

    if(event.dbIdArray.length) {

      viewer.select([]);

      event.fragIdsArray.forEach(function (fragId) {

        if (typeof _material == 'string') {

          var renderProxy = viewer.impl.getRenderProxy(
            viewer.model,
            fragId);

          setMaterialOverlay(
            renderProxy,
            _material);
        }
        else {

          setMaterial(fragId, _material);
        }
      });
    }
  }

  ///////////////////////////////////////////////////////////////////////////
  // set material
  //
  ///////////////////////////////////////////////////////////////////////////
  function setMaterial(fragId, material) {

    viewer.model.getFragmentList().setMaterial(
      fragId, material);

    viewer.impl.invalidate(true);
  }

  ///////////////////////////////////////////////////////////////////////////
  // set material with overlay
  //
  ///////////////////////////////////////////////////////////////////////////
  function setMaterialOverlay(renderProxy, materialName) {

    var meshProxy = new THREE.Mesh(
      renderProxy.geometry,
      renderProxy.material);

    meshProxy.matrix.copy(renderProxy.matrixWorld);
    meshProxy.matrixWorldNeedsUpdate = true;
    meshProxy.matrixAutoUpdate = false;
    meshProxy.frustumCulled = false;

    viewer.impl.addOverlay(materialName, meshProxy);

    viewer.impl.invalidate(true);
  }

  ///////////////////////////////////////////////////////////////////////////
  // add new material
  //
  ///////////////////////////////////////////////////////////////////////////
  function addMaterial(color) {

    var material = new THREE.MeshPhongMaterial({
      color: color
    });

    viewer.impl.matman().addMaterial(
      guid(),
      material);

    return material;
  }

  ///////////////////////////////////////////////////////////////////////////
  // add new textured material
  //
  ///////////////////////////////////////////////////////////////////////////
  function addTexMaterial(texture) {

    var tex = THREE.ImageUtils.loadTexture(
      texture);

    tex.wrapS  = THREE.RepeatWrapping;
    tex.wrapT = THREE.RepeatWrapping;

    var material = new THREE.MeshPhongMaterial({
      map: tex
    });

    var materialName = guid();

    viewer.impl.createOverlayScene(
      materialName,
      material);

    return materialName;
  }
};

Autodesk.ADN.Viewing.Extension.Material.prototype =
  Object.create(Autodesk.Viewing.Extension.prototype);

Autodesk.ADN.Viewing.Extension.Material.prototype.constructor =
  Autodesk.ADN.Viewing.Extension.Material;

Autodesk.Viewing.theExtensionManager.registerExtension(
  'Autodesk.ADN.Viewing.Extension.Material',
  Autodesk.ADN.Viewing.Extension.Material);

