var oViewer = null;
var oViewer2d = null;
var instanceTree = null;
var config3d = {
	extensions: [
		'Autodesk.ADN.Viewing.Extension.Material'
	]
};
var _type = null;
var fid = null;
var rs = null;
var _bl = null;
var _flid = null;
var stype = null;
var _page = null;
//type 是3d或者2d图
//path表示模型地址
//viewerContainer  模型装载位置 div的id
//bl表示bl的id  
//tagtype  表示问题类型 1安全隐患，2质量问题
function InitializerModel(type, path, viewerContainer) {
		var options = { 'docid': path, env: 'Local' };
        //oViewer = new Autodesk.Viewing.Private.GuiViewer3D($("#" + viewerContainer)[0], {}); // With toolbar
        oViewer = new Autodesk.Viewing.Viewer3D($("#" + viewerContainer)[0], {});
		Autodesk.Viewing.Initializer(options, function () {
		    oViewer.initialize();
		    oViewer.setBackgroundColor(244, 246, 249, 244, 246, 249);
			oViewer.addEventListener(Autodesk.Viewing.SELECTION_CHANGED_EVENT, onViewerItemSelected);
			oViewer.addEventListener(Autodesk.Viewing.GEOMETRY_LOADED_EVENT, function (event) {
			    oViewer.fitToView([]);
			    if (rs == "1") {
			        $.ajax({
			            url: "/api/services/app/ModelAppServices/SetModelColor",
			            type: "POST",
			            data: { "BLLineGuid": _bl, "FLLineGuid": _flid, "Type": _type },
			            success: function (datajson) {
			                if (datajson != null) {
			                    datajson.result.forEach(function (subFragId) {
			                        if (subFragId.color != "") {
			                            var colorHexStr = parseInt(subFragId.color.toString().replace('#', '0x'), 16);
			                            _material = addMaterial(colorHexStr);
			                            setMaterial(subFragId.fragid, _material);
			                        }
			                    });
			                }
			            },
			            error: function () {
			            }
			        });
			    }

                if (rs == "2") {
                    $.ajax({
                        url: "/api/services/app/ModelAppServices/GetModeldbID",
                        type: "POST",
                        data: { "BLLineGuid": _bl, "FLLineGuid": _flid, "Type": _type },
                        success: function (datajson) {
                            if (datajson != null) {
                                datajson.result.forEach(function (subFragId) {
                                    if (subFragId.color != "") {
                                        var colorHexStr = parseInt(subFragId.color.toString().replace('#', '0x'), 16);
                                        _material = addMaterial(colorHexStr);
                                        setMaterial(subFragId.fragid, _material);
                                    }
                                });
                            }
                        },
                        error: function () {
                        }
                    });
                }

			});
			oViewer.loadModel(options.docid);
		});
	
	
}

function clearCurrentModel(containerId) {
	tid = null;
	tagtype = null;
	var viewerElement = document.getElementById('viewer3d');
	if (viewerElement != null) {
		var container = document.getElementById(containerId);
		container.innerHTML = '';
	}
}

//模型点击事件
function onViewerItemSelected(event) {
	
}

//模型染色
function RSModel(color,fragidarray)
{
    fragidarray.forEach(function (subFragId) {
            var colorHexStr = parseInt(color.toString().replace('#', '0x'), 16);
            _material = addMaterial(colorHexStr);
            setMaterial(subFragId, _material);
    });
}

//模型选择
function Selectmodel(dbarray)
{
    oViewer.select(dbarray);
}
//模型孤立
function Isolatemodel(dbarray) {
    oViewer.isolate(dbarray);
}

function FitModel(dbarray)
{
    oViewer.fitToView(dbarray);
}

function Hide(dbarray) {
    oViewer.hide(dbarray);
}

function Show(dbarray) {
    oViewer.show(dbarray);
}


//模型切换
//3d的时候切换3d模型，2d的时候切换2d模型
function loadcmmodel(modeltype, path) {
		oViewer.tearDown();
		oViewer.setUp({ env: 'Local' });
		oViewer.loadModel(dpath);
}
///////////////////////////////////////////////////////////////////////////
// set material
//
///////////////////////////////////////////////////////////////////////////
function setMaterial(fragId, material) {

    oViewer.model.getFragmentList().setMaterial(
      fragId, material);

    oViewer.impl.invalidate(true);
}
///////////////////////////////////////////////////////////////////////////
// add new material
//
///////////////////////////////////////////////////////////////////////////
function addMaterial(color) {

    var material = new THREE.MeshPhongMaterial({
        color: color
    });

    oViewer.impl.matman().addMaterial(
      newGuid(),
      material);

    return material;
}
function newGuid() {

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